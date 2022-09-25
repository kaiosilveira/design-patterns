using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public class ConcreteWidgetMediator : WidgetMediator
{
  private List<Widget> widgets;

  public ConcreteWidgetMediator()
  {
    this.widgets = new List<Widget>();
  }

  public void RegisterEvent(ApplicationEvent e)
  {
    if (e.Type == ApplicationEventType.CLOCK_TICK) HandleClockTick(e);
    if (e.Type == ApplicationEventType.ALARM_TRIGGERED) HandleAlarmTriggered(e);
    if (e.Type == ApplicationEventType.TEMPERATURE_CHANGED) HandleTemperatureChange(e);
  }

  private void HandleTemperatureChange(ApplicationEvent e)
  {
    var display = GetWidgetOrThrowException<Display>(WidgetType.DISPLAY);
    var newTemperature = e.Data ?? throw new InvalidCastException();
    display.SetCurrentTemperature(Convert.ToInt32(newTemperature));
  }

  private void HandleAlarmTriggered(ApplicationEvent e)
  {
    var coffeePot = GetWidgetOrThrowException<CoffeePot>(WidgetType.COFFEE_POT);
    var display = GetWidgetOrThrowException<Display>(WidgetType.DISPLAY);

    coffeePot.StartBrewing();
    display.DisplayUpcomingEvents();
    display.DisplayTemperature();
  }

  private T GetWidgetOrThrowException<T>(WidgetType type)
  {
    var possiblyNullWidget = GetWidgetsOfType<T>(type).FirstOrDefault();
    return possiblyNullWidget ?? throw new WidgetNotRegisteredException(type);
  }

  private void HandleClockTick(ApplicationEvent e)
  {
    var parsedDataObj = e.Data ?? throw new InvalidDateTimeTickException();

    GetWidgetsOfType<Alarm>(WidgetType.ALARM)
      .ForEach(alarm => alarm.CheckTime((DateTime)parsedDataObj));

    GetWidgetsOfType<Sprinkler>(WidgetType.SPRINKLER)
      .ForEach(sprinkler => sprinkler.CheckTime((DateTime)parsedDataObj));
  }

  private List<T> GetWidgetsOfType<T>(WidgetType type)
  {
    var result = new List<T>();

    widgets
      .Where(widget => widget.GetWidgetType() == type)
      .ToList()
      .ForEach(widget => result.Add(((T)widget)));

    return result;
  }

  public void AddWidget(Widget widget)
  {
    this.widgets.Add(widget);
  }

  public int GetWidgetCount()
  {
    return this.widgets.Count;
  }
}