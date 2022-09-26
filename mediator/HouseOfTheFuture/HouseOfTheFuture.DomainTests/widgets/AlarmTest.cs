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
    var widgetHub = new Mock<WidgetHub>();
    var schedule = new Mock<Schedule>();
    schedule.Setup(s => s.Describe()).Returns("Saturday: 07:00 | Sunday: 07:00");

    var alarm = new ConcreteAlarm(mediator: widgetHub.Object);
    alarm.SetSchedule(schedule: schedule.Object);

    Assert.Equal("Saturday: 07:00 | Sunday: 07:00", alarm.Describe());
  }

  [Fact]
  public void TestEmitsAlarmTriggeredIfScheduledTimeMatchesCurrentTime()
  {
    var widgetHub = new Mock<WidgetHub>();
    var schedule = new Mock<Schedule>();
    schedule.Setup(s => s.Matches(It.IsAny<DateTime>())).Returns(true);
    schedule.Setup(s => s.DescribeMatch(It.IsAny<DateTime>())).Returns("Monday, 07:00");

    var alarm = new ConcreteAlarm(mediator: widgetHub.Object);
    alarm.SetSchedule(schedule: schedule.Object);

    alarm.CheckTime(DateTime.Now);

    widgetHub.Verify(
      m => m.RegisterEvent(
        It
        .Is<ApplicationEvent>(e => (string)(e.Data ?? "") == "It's Monday, 07:00!"
          && e.Type == ApplicationEventType.ALARM_TRIGGERED
        )
      ),
      Times.Once()
    );
  }
}