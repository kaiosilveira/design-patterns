using Xunit;
using Moq;
using System;
using System.Linq;
using HouseOfTheFuture.Domain.Widgets;

public class DisplayTest
{
  [Fact]
  public void TestSetCurrentTime()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);
    var date = DateTime.Now;

    display.SetCurrentDateTime(date);

    Assert.Equal(date, display.CurrentDateTime);
  }

  [Fact]
  public void TestDisplayCurrentTemperature_ReturnsDefaultIfTemperatureIsUnknown()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);

    var currentTemp = display.ShowCurrentTemperature();

    Assert.Equal("-- °C", currentTemp);
  }

  [Fact]
  public void TestSetTemperature_UpdatesTheCurrentTemperature()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);

    display.SetCurrentTemperature(38);
    var currentTemp = display.ShowCurrentTemperature();

    Assert.Equal("38 °C", currentTemp);
  }

  [Fact]
  public void TestAppendUpcomingEvent_AddsAnItemToTheList()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);
    var eventDate = new DateTime(2022, 10, 26, 12, 0, 0);
    display.AppendUpcomingEvent(
      at: eventDate, description: "Meeting with Daniel"
    );

    Assert.Equal(eventDate, display.UpcomingEvents.First().Key);
    Assert.Equal("Meeting with Daniel", display.UpcomingEvents.First().Value);
  }

  [Fact]
  public void TestDisplayUpcomingEvents_ReturnsDefaultTextIfNoEventsWereRegistered()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);

    var upcomingEventsText = display.ShowUpcomingEvents();

    Assert.Equal("No upcoming events", upcomingEventsText);
  }

  [Fact]
  public void TestDisplayUpcomingEvents_ReturnsTheListOfUpcomingEventsAsString()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);

    display.AppendUpcomingEvent(
      at: new DateTime(2022, 10, 26, 9, 0, 0),
      description: "Breakfast with Gab"
    );

    display.AppendUpcomingEvent(
      at: new DateTime(2022, 10, 26, 12, 0, 0),
      description: "Meeting with Daniel"
    );

    var upcomingEventsText = display.ShowUpcomingEvents();

    Assert.Equal("[26/10, 09:00] Breakfast with Gab\n[26/10, 12:00] Meeting with Daniel", upcomingEventsText);
  }

  [Fact]
  public void TestNotifyCoffeeReady()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(widgetHub.Object);

    display.NotifyCoffeeReady();

    Assert.Single(display.Notifications);
    Assert.Collection(
      display.Notifications,
      notification => Assert.Equal("Coffee is ready!", notification)
    );
  }

  [Fact]
  public void TestNotifyAlarmTriggered()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(widgetHub.Object);
    var alarmDescription = "It's Sunday, 09:00!";

    display.NotifyAlarmTriggered(alarmDescription);

    Assert.Single(display.Notifications);
    Assert.Collection(
      display.Notifications,
      notification => Assert.Equal("It's Sunday, 09:00!", notification)
    );
  }

  [Fact]
  public void TestShowNotifications_ReturnsDefaultTextIfNoNewNotificationsWereRegistered()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);

    var notificationsText = display.ShowNotifications();

    Assert.Equal("No new notifications", notificationsText);
  }

  [Fact]
  public void TestShowNotifications_ReturnsTheListOfNotifications()
  {
    var widgetHub = new Mock<WidgetHub>();
    var display = new ConcreteDisplay(mediator: widgetHub.Object);

    display.NotifyAlarmTriggered("It's Sunday, 09:00!");
    display.NotifyCoffeeReady();

    var notificationsText = display.ShowNotifications();

    Assert.Equal(
      "Notifications:\nIt's Sunday, 09:00!\nCoffee is ready!",
      notificationsText
    );
  }
}