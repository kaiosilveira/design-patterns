using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.ValueObjects;

public class ConcreteMediatorTest
{
  [Fact]
  public void TestGetWidgetCount_ReturnsZeroIfWidgetListIsEmpty()
  {
    var mediator = new ConcreteWidgetMediator();
    Assert.Equal(0, mediator.GetWidgetCount());
  }

  [Fact]
  public void TestAddWidget()
  {
    var alarm = new Mock<Alarm>();
    var mediator = new ConcreteWidgetMediator();

    mediator.AddWidget(widget: alarm.Object);

    Assert.Equal(1, mediator.GetWidgetCount());
  }

  [Fact]
  public void TestClockTick_ThrowsErrorIfDateObjectIsNull()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    Assert.Throws<InvalidDateTimeTickException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestClockTick_FiresCheckTimeOnAlarmAndSprinkler()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    alarm.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
    sprinkler.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }

  [Fact]
  public void TestClockTick_ThrowsExceptionIfNoDisplayIsRegistered()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestClockTick_UpdatesDisplayCurrentDateTime()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var date = DateTime.Now;
    var e = new ApplicationEvent(data: date, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    display.Verify(d => d.SetCurrentDateTime(date), Times.Once());
  }

  [Fact]
  public void TestAlarmTriggered_ThrowsExceptionIfNoCoffeePotWasRegistered()
  {
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetMediator();

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestAlarmTriggered_StartsTheBrewingProcessOnCoffeePot()
  {
    var coffeePot = new Mock<CoffeePot>();
    var display = new Mock<Display>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(coffeePot.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    coffeePot.Verify(cp => cp.StartBrewing(), Times.Once());
  }

  [Fact]
  public void TestAlarmTriggered_ThrowsExceptionIfNoDisplayWasRegistered()
  {
    var coffeePot = new Mock<CoffeePot>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(coffeePot.Object);

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestAlarmTriggered_DisplaysGoodMorningMessage()
  {
    var display = new Mock<Display>();
    var coffeePot = new Mock<CoffeePot>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(display.Object);
    mediator.AddWidget(coffeePot.Object);

    mediator.RegisterEvent(e);

    display.Verify(cp => cp.ShowGoodMorningMessage(), Times.Once());
  }

  [Fact]
  public void TestTemperatureChanged_ThrowsExceptionIfDisplayWidgetIsNotRegistered()
  {
    var newTemperature = 35;
    var e = new ApplicationEvent(
      data: newTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetMediator();
    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestTemperatureChanged_ThrowsExceptionIfNewTemperatureIsInvalid()
  {
    var display = new Mock<Display>();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(display.Object);

    Assert.Throws<InvalidCastException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestTemperatureChanged_ThrowsExceptionIfNewTemperatureIsNotInteger()
  {
    var display = new Mock<Display>();
    var e = new ApplicationEvent(
      data: "invalid integer", type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(display.Object);

    Assert.Throws<FormatException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestTemperatureChanged_UpdatesDisplay()
  {
    var newTemperature = 35;
    var display = new Mock<Display>();
    var e = new ApplicationEvent(
      data: newTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    display.Verify(d => d.SetCurrentTemperature(It.IsAny<int>()), Times.Once());
  }

  [Fact]
  public void TestNewUpcomingEvent_ThrowsExceptionIfThereAreNoDisplaysRegistered()
  {
    var mediator = new ConcreteWidgetMediator();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.NEW_UPCOMING_EVENT
    );

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestNewUpcomingEvent_ThrowsExceptionIfCalendarEventIsInvalid()
  {
    var display = new Mock<Display>();
    var mediator = new ConcreteWidgetMediator();
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
    var mediator = new ConcreteWidgetMediator();
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