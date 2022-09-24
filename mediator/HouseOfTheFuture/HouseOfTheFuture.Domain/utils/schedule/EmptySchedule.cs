namespace HouseOfTheFuture.Domain.Utils;

public class EmptySchedule
{
  public bool Matches(DateTime time)
  {
    return false;
  }
}