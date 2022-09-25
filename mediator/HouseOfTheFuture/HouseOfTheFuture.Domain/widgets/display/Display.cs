namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Display : Widget
{
  public abstract void SetCurrentTemperature(int temp);

  public abstract string DisplayTemperature();

  public WidgetType GetWidgetType()
  {
    return WidgetType.DISPLAY;
  }
}

