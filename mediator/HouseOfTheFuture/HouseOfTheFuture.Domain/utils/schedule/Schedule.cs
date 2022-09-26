namespace HouseOfTheFuture.Domain.Utils;

public interface Schedule
{
  bool Matches(DateTime time);
  string Describe();
  string DescribeMatch(DateTime time);
}