using Xunit;
using System;

namespace HouseOfTheFuture.DomainTests;

public enum ApplicationEventType
{
  CALENDAR_TICK,
  ALARM_TRIGGERED,
  COFFEE_READY
}

public class Mediator { }

public class Alarm
{
  private Mediator mediator;

  public Alarm(Mediator mediator)
  {
    this.mediator = mediator;
  }

  void CheckTime(DateTime time)
  { }

  void Emit() { }
}

public class UnitTest1
{
  [Fact]
  public void Test1()
  {

  }
}