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
    switch (e.Type)
    {
      case ApplicationEventType.CLOCK_TICK:
        HandleClockTick(e);
        break;
      default:
        break;
    }
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