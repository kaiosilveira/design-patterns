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
}