using Xunit;
using System;
using System.Collections.Generic;
using HouseOfTheFuture.Domain.Utils;

public class ScheduleTest
{
  [Fact]
  public void TestSetup()
  {
    var hour = 7;
    var minute = 0;
    var second = 0;
    var daysOfWeek = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
    var schedule = new ConcreteSchedule(daysOfWeek, hour, minute, second);

    Assert.Equal(hour, schedule.ScheduledHour);
    Assert.Equal(minute, schedule.ScheduledMinute);
    Assert.Equal(daysOfWeek, schedule.ScheduledDaysOfWeek);
  }

  [Fact]
  public void TestMatch()
  {
    var hour = 7;
    var minute = 0;
    var second = 0;
    var daysOfWeek = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };

    var schedule = new ConcreteSchedule(daysOfWeek, hour, minute, second);

    var scheduledDateTime = new DateTime(year: 2022, month: 9, day: 24, hour, minute, second);
    Assert.True(schedule.Matches(scheduledDateTime));

    var unscheduledDateTime = new DateTime(year: 2022, month: 9, day: 21, hour, minute, second);
    Assert.False(schedule.Matches(unscheduledDateTime));
  }
}