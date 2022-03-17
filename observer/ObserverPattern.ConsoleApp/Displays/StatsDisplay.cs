using ObserverPattern.Domain.Interfaces;
using ObserverPattern.Domain.Weather;
using ObserverPattern.Observable;

namespace ObserverPattern.Domain.Displays;

public class StatsDisplay : Display, Observer<WeatherDataState>
{
  private List<double> temperatures;
  public StatsDisplay(Subject<WeatherDataState> subject)
  {
    subject.Attach(this);
    this.temperatures = new List<double>() { };
  }

  public string GetDisplayText()
  {
    bool listHasItems = this.temperatures.ToArray().Length > 0;
    var minTemp = listHasItems ? Math.Round(this.temperatures.Min(), 1) : 0;
    var maxTemp = listHasItems ? Math.Round(this.temperatures.Max(), 1) : 0;
    var avgTemp = listHasItems ? Math.Round(this.temperatures.Average(), 1) : 0;
    return $"Avg temp: {avgTemp}*C | Min. temp: {minTemp}*C | Max. temp: {maxTemp}*C";
  }

  public void Update(WeatherDataState state)
  {
    this.temperatures.Add(state.Temperature);
  }
}