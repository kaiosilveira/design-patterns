using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

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
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);

    Assert.Throws<InvalidDateTimeTickException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestClockTick_FiresCheckTimeOnAlarmAndSprinkler()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);

    mediator.RegisterEvent(e);

    alarm.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
    sprinkler.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
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
  public void TestAlarmTriggered_DisplaysUpcomingEvents()
  {
    var display = new Mock<Display>();
    var coffeePot = new Mock<CoffeePot>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(display.Object);
    mediator.AddWidget(coffeePot.Object);

    mediator.RegisterEvent(e);

    display.Verify(cp => cp.DisplayUpcomingEvents(), Times.Once());
  }

  [Fact]
  public void TestAlarmTriggered_DisplaysCurrentTemperature()
  {
    var display = new Mock<Display>();
    var coffeePot = new Mock<CoffeePot>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetMediator();
    mediator.AddWidget(display.Object);
    mediator.AddWidget(coffeePot.Object);

    mediator.RegisterEvent(e);

    display.Verify(cp => cp.DisplayTemperature(), Times.Once());
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
}