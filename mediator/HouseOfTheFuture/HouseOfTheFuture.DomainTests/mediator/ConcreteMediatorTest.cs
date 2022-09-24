using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public class ConcreteMediatorTest
{
  [Fact]
  public void TestThrowsErrorIfDateObjectIsNullWhenReceivingClockTick()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var mediator = new ConcreteMediator(new List<Widget>() { alarm.Object, sprinkler.Object });
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.CLOCK_TICK);

    Assert.Throws<InvalidDateTimeTickException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestFiresCheckTimeOnAlarmAndSprinklerWhenReceivingClockTick()
  {
    var alarm = new Mock<Alarm>();
    var sprinkler = new Mock<Sprinkler>();
    var mediator = new ConcreteMediator(new List<Widget>() { alarm.Object, sprinkler.Object });
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    mediator.RegisterEvent(e);

    alarm.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
    sprinkler.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }
}