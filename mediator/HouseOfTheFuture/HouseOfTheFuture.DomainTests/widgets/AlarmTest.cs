using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.DomainTests;

public class AlarmTest
{
  [Fact]
  public void TestDescribesTheCurrentSetup()
  {
    var mockedMediatorWrapper = new Mock<WidgetHub>();
    var mockedScheduleWrapper = new Mock<Schedule>();
    mockedScheduleWrapper.Setup(s => s.Describe()).Returns("Saturday: 07:00 | Sunday: 07:00");

    var alarm = new ConcreteAlarm(mediator: mockedMediatorWrapper.Object);
    alarm.SetSchedule(schedule: mockedScheduleWrapper.Object);

    Assert.Equal("Saturday: 07:00 | Sunday: 07:00", alarm.Describe());
  }

  [Fact]
  public void TestEmitsAlarmTriggeredIfScheduledTimeMatchesCurrentTime()
  {
    var mockedMediatorWrapper = new Mock<WidgetHub>();
    var mockedScheduleWrapper = new Mock<Schedule>();
    mockedScheduleWrapper.Setup(s => s.Matches(It.IsAny<DateTime>())).Returns(true);

    var alarm = new ConcreteAlarm(mediator: mockedMediatorWrapper.Object);
    alarm.SetSchedule(schedule: mockedScheduleWrapper.Object);

    alarm.CheckTime(DateTime.Now);

    mockedMediatorWrapper.Verify(
      m => m.RegisterEvent(
        It.Is<ApplicationEvent>(e => e.Data == null && e.Type == ApplicationEventType.ALARM_TRIGGERED)
      ),
      Times.Once()
    );
  }
}