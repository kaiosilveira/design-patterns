using System;
using Xunit;
using HouseOfTheFuture.Domain.Utils;

public class ScheduleEntryTest
{
  [Fact]
  public void TestToString_ReturnsDateAndTime()
  {
    var entry = new ScheduleEntry(dayOfWeek: DayOfWeek.Friday, hour: 9, minute: 0);
    Assert.Equal("Friday, 09:00", entry.AsString());
  }

  [Fact]
  public void TestToString_AllowsCustomSeparator()
  {
    var entry = new ScheduleEntry(dayOfWeek: DayOfWeek.Friday, hour: 9, minute: 0);
    Assert.Equal("Friday: 09:00", entry.AsString(separator: ":"));
  }
}
