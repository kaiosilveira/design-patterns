using Xunit;
using Moq;
using System;
using System.Linq;
using HouseOfTheFuture.Domain.Widgets;

public class DisplayTest
{
  [Fact]
  public void TestDisplayCurrentTemperature_ReturnsDefaultIfTemperatureIsUnknown()
  {
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);

    var currentTemp = display.DisplayTemperature();

    Assert.Equal("-- °C", currentTemp);
  }

  [Fact]
  public void TestSetTemperature_UpdatesTheCurrentTemperature()
  {
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);

    display.SetCurrentTemperature(38);
    var currentTemp = display.DisplayTemperature();

    Assert.Equal("38 °C", currentTemp);
  }

  [Fact]
  public void TestAppendUpcomingEvent_AddsAnItemToTheList()
  {
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);
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
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);

    var upcomingEventsText = display.DisplayUpcomingEvents();

    Assert.Equal("No upcoming events", upcomingEventsText);
  }

  [Fact]
  public void TestDisplayUpcomingEvents_ReturnsTheListOfUpcomingEventsAsString()
  {
    var mockedMediator = new Mock<Mediator>();
    var display = new ConcreteDisplay(mediator: mockedMediator.Object);

    display.AppendUpcomingEvent(
      at: new DateTime(2022, 10, 26, 9, 0, 0),
      description: "Breakfast with Gab"
    );

    display.AppendUpcomingEvent(
      at: new DateTime(2022, 10, 26, 12, 0, 0),
      description: "Meeting with Daniel"
    );

    var upcomingEventsText = display.DisplayUpcomingEvents();

    Assert.Equal("[26/10, 09:00] Breakfast with Gab | [26/10, 12:00] Meeting with Daniel", upcomingEventsText);
  }
}