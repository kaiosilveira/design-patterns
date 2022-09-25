using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public class ConcreteMediatorTest
{
  [Fact]
  public void TestClockTick_ThrowsErrorIfDateObjectIsNull()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var widgets = new List<Widget>() { alarm.Object, sprinkler.Object };
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteMediator(widgets);
    Assert.Throws<InvalidDateTimeTickException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestClockTick_FiresCheckTimeOnAlarmAndSprinkler()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var widgets = new List<Widget>() { alarm.Object, sprinkler.Object };
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteMediator(widgets);
    mediator.RegisterEvent(e);

    alarm.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
    sprinkler.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }

  [Fact]
  public void TestAlarmTriggered_ThrowsExceptionIfNoCoffeePotWasRegistered()
  {
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteMediator(widgets: new List<Widget>());

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestAlarmTriggered_StartsTheBrewingProcessOnCoffeePot()
  {
    var coffeePot = new Mock<CoffeePot>();
    var display = new Mock<Display>();
    var widgets = new List<Widget>() { coffeePot.Object, display.Object };

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteMediator(widgets);
    mediator.RegisterEvent(e);

    coffeePot.Verify(cp => cp.StartBrewing(), Times.Once());
  }

  [Fact]
  public void TestAlarmTriggered_ThrowsExceptionIfNoDisplayWasRegistered()
  {
    var coffeePot = new Mock<CoffeePot>();
    var widgets = new List<Widget>() { coffeePot.Object };

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteMediator(widgets);

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }


  [Fact]
  public void TestAlarmTriggered_DisplaysUpcomingEvents()
  {
    var display = new Mock<Display>();
    var coffeePot = new Mock<CoffeePot>();
    var widgets = new List<Widget>() { display.Object, coffeePot.Object };

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteMediator(widgets);
    mediator.RegisterEvent(e);

    display.Verify(cp => cp.DisplayUpcomingEvents(), Times.Once());
  }

  [Fact]
  public void TestTemperatureChanged_ThrowsExceptionIfDisplayWidgetIsNotRegistered()
  {
    var newTemperature = 35;
    var widgets = new List<Widget>();
    var e = new ApplicationEvent(
      data: newTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteMediator(widgets);
    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestTemperatureChanged_ThrowsExceptionIfNewTemperatureIsInvalid()
  {
    var display = new Mock<Display>();
    var widgets = new List<Widget>() { display.Object };
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteMediator(widgets);
    Assert.Throws<InvalidCastException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestTemperatureChanged_ThrowsExceptionIfNewTemperatureIsNotInteger()
  {
    var display = new Mock<Display>();
    var widgets = new List<Widget>() { display.Object };
    var e = new ApplicationEvent(
      data: "invalid integer", type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteMediator(widgets);
    Assert.Throws<FormatException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestTemperatureChanged_UpdatesDisplay()
  {
    var newTemperature = 35;
    var display = new Mock<Display>();
    var widgets = new List<Widget>() { display.Object };
    var e = new ApplicationEvent(
      data: newTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteMediator(widgets);
    mediator.RegisterEvent(e);

    display.Verify(d => d.SetCurrentTemperature(It.IsAny<int>()), Times.Once());
  }
}