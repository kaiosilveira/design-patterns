using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.ValueObjects;
using HouseOfTheFuture.Domain.Exceptions;

public class ConcreteWidgetHubTest
{
  [Fact]
  public void TestGetWidgetCount_ReturnsZeroIfWidgetListIsEmpty()
  {
    var mediator = new ConcreteWidgetHub();
    Assert.Equal(0, mediator.GetWidgetCount());
  }

  [Fact]
  public void TestAddWidget()
  {
    var alarm = new Mock<Alarm>();
    var mediator = new ConcreteWidgetHub();

    mediator.AddWidget(widget: alarm.Object);

    Assert.Equal(1, mediator.GetWidgetCount());
  }

  [Fact]
  public void TestNewUpcomingEvent_ThrowsExceptionIfThereAreNoDisplaysRegistered()
  {
    var mediator = new ConcreteWidgetHub();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.NEW_UPCOMING_EVENT
    );

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestNewUpcomingEvent_ThrowsExceptionIfCalendarEventIsInvalid()
  {
    var display = new Mock<Display>();
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);

    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.NEW_UPCOMING_EVENT
    );

    Assert.Throws<InvalidCalendarEventException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestNewUpcomingEvent_AppendsEventToDisplay()
  {
    var display = new Mock<Display>();
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);

    var calendarEvent = new CalendarEvent(
      at: DateTime.Now.AddHours(3), description: "Meeting with Daniel"
    );
    var e = new ApplicationEvent(
      data: calendarEvent, type: ApplicationEventType.NEW_UPCOMING_EVENT
    );

    mediator.RegisterEvent(e);

    display.Verify(d =>
      d.AppendUpcomingEvent(calendarEvent.At, calendarEvent.Description),
      Times.Once()
    );
  }

  [Fact]
  public void TestCoffeeIsReady_ThrowsExceptionIfThereAreNoDisplaysRegistered()
  {
    var mediator = new ConcreteWidgetHub();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.COFFEE_READY
    );

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestCoffeeIsReady_CreatesDisplayNotification()
  {
    var display = new Mock<Display>();
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.COFFEE_READY
    );

    mediator.RegisterEvent(e);

    display.Verify(d => d.NotifyCoffeeReady(), Times.Once());
  }
}