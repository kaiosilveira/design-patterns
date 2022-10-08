using ObserverPattern.Domain.Weather;

public class DefaultWeatherDataState : WeatherDataState
{
  public DefaultWeatherDataState() : base(0, 0, 0) { }
}