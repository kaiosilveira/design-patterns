using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Exceptions;

public class ConcreteWidgetHubTest_ClockTick
{
  [Fact]
  public void TestThrowsErrorIfDateObjectIsNull()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    Assert.Throws<InvalidDateTimeTickException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestFiresCheckTimeOnAlarm()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    sprinkler.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }

  [Fact]
  public void TestFiresCheckTimeOnSprinkler()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    sprinkler.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }

  [Fact]
  public void TestFiresCheckTimeOnCoffeePot()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var coffeePot = new Mock<CoffeePot>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);
    mediator.AddWidget(coffeePot.Object);

    mediator.RegisterEvent(e);

    coffeePot.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }

  [Fact]
  public void TestThrowsExceptionIfNoDisplayIsRegistered()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestUpdatesDisplayCurrentDateTime()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var display = new Mock<Display>();
    var date = DateTime.Now;
    var e = new ApplicationEvent(data: date, type: ApplicationEventType.CLOCK_TICK);

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(alarm.Object);
    mediator.AddWidget(sprinkler.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    display.Verify(d => d.SetCurrentDateTime(date), Times.Once());
  }
}