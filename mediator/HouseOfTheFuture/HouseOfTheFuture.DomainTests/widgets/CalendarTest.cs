using System;
using Moq;
using Xunit;
using HouseOfTheFuture.Domain.ValueObjects;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;

public class CalendarTest
{
  [Fact]
  public void TestAddEvent_AppendsAnItemToTheList()
  {
    var mediator = new Mock<WidgetMediator>();
    var calendar = new ConcreteCalendar(mediator: mediator.Object);

    var calendarEvent = new CalendarEvent(at: DateTime.Now, description: "Meeting with Dan");
    calendar.AddEvent(calendarEvent);

    Assert.Collection(
      calendar.AllEvents, firstEvent =>
      {
        Assert.Equal(calendarEvent.At, firstEvent.At);
        Assert.Equal(calendarEvent.Description, firstEvent.Description);
      }
    );
  }

  [Fact]
  public void TestAddEvent_FiresEventNotifyingMediator()
  {
    var mediator = new Mock<WidgetMediator>();
    var calendar = new ConcreteCalendar(mediator: mediator.Object);

    var calendarEvent = new CalendarEvent(at: DateTime.Now, description: "Meeting with Dan");
    calendar.AddEvent(calendarEvent);

    mediator
      .Verify(m => m
        .RegisterEvent(It
          .Is<ApplicationEvent>(e => e.Data == calendarEvent
            && e.Type == ApplicationEventType.NEW_UPCOMING_EVENT
          )
        )
      );
  }
}