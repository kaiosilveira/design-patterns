namespace HouseOfTheFuture.Domain.Widgets;

public class ConcreteDisplay : Display
{
  private readonly Mediator mediator;
  private int? currentTemperature;

  public ConcreteDisplay(Mediator mediator)
  {
    this.mediator = mediator;
  }

  public void SetCurrentTemperature(int temp)
  {
    this.currentTemperature = temp;
  }

  public string DisplayTemperature()
  {
    var tempNumber = currentTemperature.HasValue ? currentTemperature.ToString() : "--";
    return $"{tempNumber} °C";
  }
}