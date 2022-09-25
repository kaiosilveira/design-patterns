namespace HouseOfTheFuture.Domain.Widgets;

public abstract class Display : Widget
{
  public WidgetType GetWidgetType()
  {
    return WidgetType.DISPLAY;
  }
}

