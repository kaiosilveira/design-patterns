namespace HouseOfTheFuture.Domain.Widgets;

public interface ClockDependentWidget : Widget
{
  void CheckTime(DateTime time);
}