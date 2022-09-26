namespace HouseOfTheFuture.Domain.Widgets;

public abstract class CoffeePot : ClockDependentWidget
{
  public abstract void StartBrewing();

  public abstract void CheckTime(DateTime time);

  public WidgetType GetWidgetType()
  {
    return WidgetType.COFFEE_POT;
  }
}