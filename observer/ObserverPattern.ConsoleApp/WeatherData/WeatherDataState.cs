namespace ObserverPattern.Domain;

public class WeatherDataState
{
  public double Temperature { get; }
  public double Pressure { get; }
  public double Humidity { get; }

  public WeatherDataState(double temperature, double pressure, double humidity)
  {
    this.Temperature = temperature;
    this.Pressure = pressure;
    this.Humidity = humidity;
  }
}
