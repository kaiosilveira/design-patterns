namespace HouseOfTheFuture.Domain.Utils;

public interface TimeProvider
{
  DateTime GetCurrentDateTime();

  bool Compare(DateTime t1, DateTime t2);
}