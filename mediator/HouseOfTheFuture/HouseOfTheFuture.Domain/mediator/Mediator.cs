using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public interface WidgetMediator
{
  void RegisterEvent(ApplicationEvent e);
  void AddWidget(Widget widget);
  int GetWidgetCount();
}