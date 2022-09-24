namespace HouseOfTheFuture.Domain.Events;

public class ApplicationEvent
{
  public readonly Object? Data;
  public readonly ApplicationEventType Type;

  public ApplicationEvent(Object? data, ApplicationEventType type)
  {
    this.Data = data;
    this.Type = type;
  }
}