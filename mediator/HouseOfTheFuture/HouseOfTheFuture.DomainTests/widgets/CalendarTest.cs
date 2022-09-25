using System;
using Moq;
using Xunit;
using HouseOfTheFuture.Domain.ValueObjects;
using HouseOfTheFuture.Domain.Widgets;

public class CalendarTest
{
  [Fact]
  public void TestAddEvent()
  {
    var mediator = new Mock<WidgetMediator>();
    var calendar = new ConcreteCalendar(mediator: mediator.Object);

    var date = DateTime.Now;
    var description = "Meeting with Dan";
    calendar.AddEvent(new CalendarEvent(date, description));

    Assert.Collection(
      calendar.AllEvents, firstEvent =>
      {
        Assert.Equal(date, firstEvent.At);
        Assert.Equal(description, firstEvent.Description);
      }
    );
  }
}