namespace HouseOfTheFuture.Domain.Utils;

public class EmptySchedule : Schedule
{
  public string Describe()
  {
    return "Empty schedule";
  }

  public bool Matches(DateTime time)
  {
    return false;
  }
}