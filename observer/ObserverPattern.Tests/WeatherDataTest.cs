using Xunit;
using ObserverPattern.Observable;
using ObserverPattern.Domain;

namespace ObserverPattern.Tests;

class MyObserver : Observer<WeatherDataState>
{
  public int NotificationsReceived = 0;
  public WeatherDataState LastStateReceived;
  public WeatherDataState Measurements
  {
    get; set;
  }

  public MyObserver()
  {
    this.LastStateReceived = new WeatherDataState(0, 0, 0);
    this.Measurements = new DefaultWeatherDataState();
  }

  public void Update(WeatherDataState state)
  {
    this.Measurements = state;
    this.NotificationsReceived++;
  }
}

public class WeatherDataTest
{
  [Fact]
  public void TestRegistersAnObserver()
  {
    float temperature = 21.3F;
    float pressure = 1.0F;
    float humidity = 49.5F;

    var observer = new MyObserver();
    var weatherData = new WeatherData();
    weatherData.Attach(observer);

    weatherData.SetMeasurements(temperature, pressure, humidity);

    Assert.Equal(1, observer.NotificationsReceived);
    Assert.Equal(temperature, observer.Measurements.Temperature);
    Assert.Equal(pressure, observer.Measurements.Pressure);
    Assert.Equal(humidity, observer.Measurements.Humidity);
  }

  [Fact]
  public void TestDeregisterAnObserver()
  {
    float temperature = 21.3F;
    float pressure = 1.0F;
    float humidity = 49.5F;

    var observer = new MyObserver();
    var weatherData = new WeatherData();
    weatherData.Attach(observer);

    weatherData.SetMeasurements(temperature, pressure, humidity);

    Assert.Equal(1, observer.NotificationsReceived);

    weatherData.Detach(observer);

    weatherData.SetMeasurements(temperature + 1.0F, pressure + 1.0F, humidity + 1.0F);

    Assert.Equal(1, observer.NotificationsReceived);
  }
}