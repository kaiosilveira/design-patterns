namespace ObserverPattern.Domain;

public class WeatherDataState
{
  public float Temperature { get; }
  public float Pressure { get; }
  public float Humidity { get; }

  public WeatherDataState(float temperature, float pressure, float humidity)
  {
    this.Temperature = temperature;
    this.Pressure = pressure;
    this.Humidity = humidity;
  }
}
