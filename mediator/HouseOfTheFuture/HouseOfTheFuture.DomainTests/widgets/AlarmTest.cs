using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;
using System.Collections.Generic;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.DomainTests;

public class AlarmTest
{
  [Fact]
  public void TestDescribesTheCurrentSetup()
  {
    var hour = 7;
    var minute = 0;
    var second = 0;
    var mockedMediatorWrapper = new Mock<Mediator>();
    var daysOfWeek = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };

    var alarm = new ConcreteAlarm(mediator: mockedMediatorWrapper.Object);
    alarm.SetSchedule(new WeeklySchedule(daysOfWeek, hour, minute, second));

    Assert.Equal("Saturday: 07:00 | Sunday: 07:00", alarm.Describe());
  }

  [Fact]
  public void TestEmitsAlarmTriggeredIfScheduledTimeMatchesCurrentTime()
  {
    var hour = 11;
    var minute = 0;
    var second = 0;
    var mockedMediatorWrapper = new Mock<Mediator>();
    var date = new DateTime(year: 2022, month: 9, day: 22, hour, minute, second);
    var daysOfWeek = new List<DayOfWeek>()
    {
      DayOfWeek.Monday,
      DayOfWeek.Tuesday,
      DayOfWeek.Wednesday,
      DayOfWeek.Thursday,
      DayOfWeek.Friday
    };

    var alarm = new ConcreteAlarm(mediator: mockedMediatorWrapper.Object);
    alarm.SetSchedule(new WeeklySchedule(daysOfWeek, hour, minute, second));
    alarm.CheckTime(date);

    mockedMediatorWrapper.Verify(
      m => m.RegisterEvent(
        It.Is<ApplicationEvent>(e => e.Data == null && e.Type == ApplicationEventType.ALARM_TRIGGERED)
      ),
      Times.Once()
    );
  }
}