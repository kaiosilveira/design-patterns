using ObserverPattern.Domain.Weather;
using ObserverPattern.Presentation.Displays;

namespace ObserverPattern;

public class Program
{
  public static void Main(string[] args)
  {
    var data = new WeatherData();
    var statsDisplay = new StatsDisplay(data);
    var conditionsDisplay = new CurrentConditionsDisplay(data);
    var heatIndexDisplay = new HeatIndexDisplay(data);

    data.SetMeasurements(11.2, 1.0, 55.0);
    data.SetMeasurements(15.3, 1.0, 50.0);
    data.SetMeasurements(21.4, 1.0, 49.0);
  }
}