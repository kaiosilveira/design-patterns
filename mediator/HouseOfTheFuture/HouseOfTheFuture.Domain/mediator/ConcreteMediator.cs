using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public class ConcreteMediator : Mediator
{
  private List<Widget> widgets;

  public ConcreteMediator(List<Widget> widgets)
  {
    this.widgets = widgets;
  }

  public void RegisterEvent(ApplicationEvent e)
  {
    if (e.Type == ApplicationEventType.CLOCK_TICK) HandleClockTick(e);
    if (e.Type == ApplicationEventType.ALARM_TRIGGERED) HandleAlarmTriggered(e);
    if (e.Type == ApplicationEventType.TEMPERATURE_CHANGED) HandleTemperatureChange(e);
  }

  private void HandleTemperatureChange(ApplicationEvent e)
  {
    var possiblyNullDisplay = GetWidgetsOfType<Display>(WidgetType.DISPLAY).FirstOrDefault();
    var display = possiblyNullDisplay ?? throw new WidgetNotRegisteredException(WidgetType.DISPLAY);
    var newTemperature = e.Data ?? throw new InvalidCastException();

    display.SetCurrentTemperature(Convert.ToInt32(newTemperature));
  }

  private void HandleAlarmTriggered(ApplicationEvent e)
  {
    var possibleCoffeePot = GetWidgetsOfType<CoffeePot>(WidgetType.COFFEE_POT).FirstOrDefault();
    var coffeePot = possibleCoffeePot ?? throw new WidgetNotRegisteredException(WidgetType.COFFEE_POT);
    coffeePot.StartBrewing();
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
}