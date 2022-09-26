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

  [Fact]
  public void TestDescribe()
  {
    var emptySchedule = new EmptySchedule();
    Assert.Equal("Empty schedule", emptySchedule.Describe());
  }

  [Fact]
  public void TestDescribeMatch_ThrowsNoMatchException()
  {
    var emptySchedule = new EmptySchedule();
    Assert.Throws<NoScheduleMatchException>(() => emptySchedule.DescribeMatch(DateTime.Now));
  }
}