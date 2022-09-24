using HouseOfTheFuture.Domain.Events;

public interface Mediator
{
  void RegisterEvent(ApplicationEventType e);
}