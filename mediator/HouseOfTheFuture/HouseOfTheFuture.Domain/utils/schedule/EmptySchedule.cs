namespace HouseOfTheFuture.Domain.Utils;

public class EmptySchedule : Schedule
{
  public string Describe()
  {
    return "Empty schedule";
  }

  public string DescribeMatch(DateTime time)
  {
    throw new NoScheduleMatchException();
  }

  public bool Matches(DateTime time)
  {
    return false;
  }
}