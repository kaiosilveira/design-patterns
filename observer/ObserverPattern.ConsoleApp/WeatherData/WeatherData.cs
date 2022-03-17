using ObserverPattern.Observable;

namespace ObserverPattern.Domain;

public class WeatherData : Subject<WeatherDataState>
{
  private WeatherDataState state;
  private List<Observer<WeatherDataState>> observers { get; set; }

  public WeatherData()
  {
    this.observers = new List<Observer<WeatherDataState>>();
    this.state = new DefaultWeatherDataState();
  }

  public void Attach(Observer<WeatherDataState> o) => this.observers.Add(o);

  public void Detach(Observer<WeatherDataState> o) => this.observers.Remove(o);

  public void Notify() => this.observers.ForEach(observer => observer.Update(this.state));

  public void SetMeasurements(float temperature, float pressure, float humidity)
  {
    this.state = new WeatherDataState(temperature, pressure, humidity);
    this.MeasurementsChanged();
  }

  private void MeasurementsChanged() => this.Notify();
}
