using Xunit;
using System;
using HouseOfTheFuture.Domain.Utils;

public class EmptyScheduleTest
{
  [Fact]
  public void TestMatchAlwaysReturnsFalse()
  {
    var emptySchedule = new EmptySchedule();
    Assert.False(emptySchedule.Matches(DateTime.Now));
  }
}