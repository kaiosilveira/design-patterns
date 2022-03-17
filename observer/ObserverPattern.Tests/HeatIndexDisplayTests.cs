using Xunit;
using System.Collections.Generic;
using ObserverPattern.Domain.Weather;
using ObserverPattern.Presentation.Displays;

namespace ObserverPattern.Tests;

public class HeatIndexDisplayTest
{
  private readonly double PRESSURE = 1.0;
  private readonly double HUMIDITY = 49.0;
  private readonly List<double> TEMPERATURES = new List<double>() {
    11.5, 12.3, 15.2, 17.7, 20.3, 21.5
  };

  [Fact]
  public void TestUpdatesInfoCorrectly()
  {
    var weatherData = new WeatherData();
    var display = new HeatIndexDisplay(weatherData);

    TEMPERATURES.ForEach(temp => display.Update(new WeatherDataState(temp, PRESSURE, HUMIDITY)));

    Assert.Equal("Heat index is: 181.53", display.GetDisplayText());
  }

  [Fact]
  public void TestReceivesUpdatesFromWeatherData()
  {
    var weatherData = new WeatherData();
    var display = new HeatIndexDisplay(weatherData);

    TEMPERATURES.ForEach(temp => weatherData.SetMeasurements(temp, PRESSURE, HUMIDITY));

    Assert.Equal("Heat index is: 181.53", display.GetDisplayText());
  }
}