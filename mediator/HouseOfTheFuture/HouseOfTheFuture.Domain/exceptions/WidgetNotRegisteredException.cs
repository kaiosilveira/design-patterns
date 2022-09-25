using HouseOfTheFuture.Domain.Widgets;

public class WidgetNotRegisteredException : Exception
{
  private static Dictionary<WidgetType, string> widgetNames = new Dictionary<WidgetType, string>()
  {
    { WidgetType.COFFEE_POT, "Coffee Pot" },
    { WidgetType.ALARM, "Alarm" },
    { WidgetType.CLOCK, "Clock" },
    { WidgetType.DISPLAY, "Display" },
  };

  public WidgetNotRegisteredException(WidgetType type)
    : base(message: $"No widgets of type '{WidgetNotRegisteredException.widgetNames[type]}' were found. Have you tried registering them first?")
  { }
}