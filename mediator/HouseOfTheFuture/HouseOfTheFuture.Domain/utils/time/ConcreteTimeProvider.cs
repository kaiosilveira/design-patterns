namespace HouseOfTheFuture.Domain.Utils;

public class ConcreteTimeProvider : TimeProvider
{
  public bool Compare(DateTime t1, DateTime t2)
  {
    return t1.Year == t2.Year
      && t1.Month == t2.Month
      && t1.Date == t2.Date
      && t1.Hour == t2.Hour
      && t1.Minute == t2.Minute
      && t1.Second == t2.Second;
  }

  public DateTime GetCurrentDateTime()
  {
    return DateTime.Now;
  }
}