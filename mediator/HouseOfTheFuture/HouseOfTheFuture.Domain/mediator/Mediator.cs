using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public interface Mediator
{
  void RegisterEvent(ApplicationEvent e);
  void AddWidget(Widget widget);
  int GetWidgetCount();
}