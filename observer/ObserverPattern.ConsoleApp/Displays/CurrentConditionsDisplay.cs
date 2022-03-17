using ObserverPattern.Observable;
using ObserverPattern.Domain.Weather;
using ObserverPattern.Domain.Interfaces;

namespace ObserverPattern.Domain.Displays;

public class CurrentConditionsDisplay : Display, Observer<WeatherDataState>
{
  private WeatherDataState weatherConditions;

  public CurrentConditionsDisplay(Subject<WeatherDataState> subject)
  {
    this.weatherConditions = new DefaultWeatherDataState();
    subject.Attach(this);
  }

  public void Update(WeatherDataState state)
  {
    this.weatherConditions = state;
  }

  public string GetDisplayText()
  {
    var temperature = this.weatherConditions.Temperature;
    var humidity = this.weatherConditions.Humidity;
    var pressure = this.weatherConditions.Pressure;
    return $"Current conditions: {temperature}*C | {humidity}% | pressure: {pressure}";
  }

  public void Display()
  {
    Console.WriteLine(GetDisplayText());
  }
}
