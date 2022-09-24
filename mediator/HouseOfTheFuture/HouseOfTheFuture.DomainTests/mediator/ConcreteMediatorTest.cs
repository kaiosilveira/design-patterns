using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public class ConcreteMediatorTest
{
  [Fact]
  public void TestFiresCheckTimeOnAlarmWhenReceivingClockTick()
  {
    var alarm = new Mock<Alarm>();
    var mediator = new ConcreteMediator(new List<Widget>() { alarm.Object });
    var e = new ApplicationEvent(data: DateTime.Now, type: ApplicationEventType.CLOCK_TICK);

    mediator.RegisterEvent(e);

    alarm.Verify(a => a.CheckTime(It.IsAny<DateTime>()), Times.Once());
  }
}