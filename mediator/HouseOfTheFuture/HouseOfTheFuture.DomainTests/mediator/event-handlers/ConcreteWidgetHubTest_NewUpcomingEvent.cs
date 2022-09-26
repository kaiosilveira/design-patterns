using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Exceptions;
using HouseOfTheFuture.Domain.ValueObjects;

public class ConcreteWidgetHubTest_NewUpcomingEvent
{
  [Fact]
  public void TestThrowsExceptionIfThereAreNoDisplaysRegistered()
  {
    var mediator = new ConcreteWidgetHub();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.NEW_UPCOMING_EVENT
    );

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestThrowsExceptionIfCalendarEventIsInvalid()
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
  public void TestAppendsEventToDisplay()
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
}