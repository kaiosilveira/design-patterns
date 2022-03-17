using ObserverPattern.Domain.Interfaces;
using ObserverPattern.Domain.Weather;
using ObserverPattern.Observable;

namespace ObserverPattern.Presentation.Displays;

public class HeatIndexDisplay : Display, Observer<WeatherDataState>
{
  private WeatherDataState weatherConditions;

  public HeatIndexDisplay(Subject<WeatherDataState> subject)
  {
    subject.Attach(this);
    this.weatherConditions = new DefaultWeatherDataState();
  }

  public void Display()
  {
    Console.WriteLine(this.GetDisplayText());
  }

  public string GetDisplayText()
  {
    return $"Heat index is: {this.CalculateHeatIndex()}";
  }

  public void Update(WeatherDataState state)
  {
    this.weatherConditions = state;
    this.Display();
  }

  private double CalculateHeatIndex()
  {
    var t = this.weatherConditions.Temperature;
    var rh = this.weatherConditions.Humidity;

    double index = (double)((16.923 + (0.185212 * t) + (5.37941 * rh) - (0.100254 * t * rh) +
            (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) +
            (0.000345372 * (t * t * rh)) - (0.000814971 * (t * rh * rh)) +
            (0.0000102102 * (t * t * rh * rh)) - (0.000038646 * (t * t * t)) + (0.0000291583 *
            (rh * rh * rh)) + (0.00000142721 * (t * t * t * rh)) +
            (0.000000197483 * (t * rh * rh * rh)) - (0.0000000218429 * (t * t * t * rh * rh)) +
            0.000000000843296 * (t * t * rh * rh * rh)) -
            (0.0000000000481975 * (t * t * t * rh * rh * rh)));

    return Math.Round(index, 2);
  }
}