namespace HouseOfTheFuture.Domain.Utils;

public class EmptySchedule : Schedule
{
  public bool Matches(DateTime time)
  {
    return false;
  }
}