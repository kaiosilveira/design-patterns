using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;

public interface WidgetHub
{
  void RegisterEvent(ApplicationEvent e);
  void AddWidget(Widget widget);
  int GetWidgetCount();
}