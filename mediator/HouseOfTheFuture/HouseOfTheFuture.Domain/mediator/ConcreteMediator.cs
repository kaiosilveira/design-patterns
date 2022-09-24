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
    this.widgets
      .Where(w => w.GetWidgetType() == WidgetType.ALARM)
      .ToList()
      .ForEach(alarm =>
      {
        var parsedDataObj = e.Data ?? DateTime.Now;
        ((Alarm)alarm).CheckTime((DateTime)parsedDataObj);
      });
  }
}