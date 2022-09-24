using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;
using System.Collections.Generic;

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

    var alarm = new Alarm(mediator: mockedMediatorWrapper.Object);
    alarm.Set(daysOfWeek, hour, minute, second);

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

    var alarm = new Alarm(mediator: mockedMediatorWrapper.Object);
    alarm.Set(daysOfWeek, hour, minute, second);
    alarm.CheckTime(date);

    mockedMediatorWrapper.Verify(
      m => m.RegisterEvent(ApplicationEventType.ALARM_TRIGGERED),
      Times.Once()
    );
  }
}