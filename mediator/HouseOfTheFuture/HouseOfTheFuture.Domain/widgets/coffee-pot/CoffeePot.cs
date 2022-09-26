namespace HouseOfTheFuture.Domain.Widgets;

public abstract class CoffeePot : ClockDependentWidget
{
  public WidgetType GetWidgetType()
  {
    return WidgetType.COFFEE_POT;
  }

  public abstract void StartBrewing();
  public abstract void CheckTime(DateTime time);
}