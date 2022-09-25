namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteDisplay
{
  private readonly Mediator mediator;

  public ConcreteDisplay(Mediator mediator)
  {
    this.mediator = mediator;
  }

  public string DisplayCurrentTemperature()
  {
    return "-- °C";
  }
}