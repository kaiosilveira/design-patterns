using Xunit;
using ObserverPattern.Domain.Displays;
using ObserverPattern.Domain.Weather;

namespace ObserverPattern.Tests;

public class CurrentConditionsDisplayTest
{
  double temperature = 21.3;
  double pressure = 1.0;
  double humidity = 49.5;

  [Fact]
  public void TestRendersTheWeatherConditionsCorrectly()
  {
    var weatherData = new WeatherData();
    var display = new CurrentConditionsDisplay(weatherData);
    display.Update(new WeatherDataState(temperature, pressure, humidity));
    var text = display.GetDisplayText();

    Assert.Equal(
      $"Current conditions: {temperature}*C | {humidity}% | pressure: {pressure}",
      text
    );
  }

  [Fact]
  public void TestReceivesUpdatesFromWeatherData()
  {
    var weatherData = new WeatherData();
    var display = new CurrentConditionsDisplay(weatherData);
    weatherData.SetMeasurements(temperature, pressure, humidity);
    var text = display.GetDisplayText();

    Assert.Equal(
      $"Current conditions: {temperature}*C | {humidity}% | pressure: {pressure}",
      text
    );
  }
}