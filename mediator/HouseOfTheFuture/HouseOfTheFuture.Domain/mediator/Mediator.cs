using HouseOfTheFuture.Domain.Events;

public interface Mediator
{
  void RegisterEvent(ApplicationEvent e);
}