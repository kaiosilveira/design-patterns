using Xunit;
using System.Linq;
using System.Collections.Generic;
using ObserverPattern.Domain.Weather;
using ObserverPattern.Domain.Displays;
using System;

namespace ObserverPattern.Tests;

public class StatsDisplayTest
{
  private readonly double PRESSURE = 1.0;
  private readonly double HUMIDITY = 49.0;
  private readonly List<double> TEMPERATURES = new List<double>() {
    11.5, 12.3, 15.2, 17.7, 20.3, 21.5
  };

  [Fact]
  public void TestRendersTextCorrectly()
  {
    var display = new StatsDisplay(new WeatherData());
    var text = display.GetDisplayText();

    Assert.Equal(
      $"Avg temp: 0*C | Min. temp: 0*C | Max. temp: 0*C",
      text
    );
  }

  [Fact]
  public void TestUpdatesInfoCorrectly()
  {
    var minTemp = Math.Round(TEMPERATURES.Min(), 1);
    var maxTemp = Math.Round(TEMPERATURES.Max(), 1);
    var avgTemp = Math.Round(TEMPERATURES.Average(), 1);

    var weatherData = new WeatherData();
    var display = new StatsDisplay(weatherData);

    TEMPERATURES.ForEach(temp => display.Update(new WeatherDataState(temp, PRESSURE, HUMIDITY)));

    Assert.Equal(
      $"Avg temp: {avgTemp}*C | Min. temp: {minTemp}*C | Max. temp: {maxTemp}*C",
      display.GetDisplayText()
    );
  }

  [Fact]
  public void TestReceivesUpdatesFromWeatherData()
  {
    var minTemp = Math.Round(TEMPERATURES.Min(), 1);
    var maxTemp = Math.Round(TEMPERATURES.Max(), 1);
    var avgTemp = Math.Round(TEMPERATURES.Average(), 1);

    var weatherData = new WeatherData();
    var display = new StatsDisplay(weatherData);

    TEMPERATURES.ForEach(temp => weatherData.SetMeasurements(temp, PRESSURE, HUMIDITY));

    Assert.Equal(
      $"Avg temp: {avgTemp}*C | Min. temp: {minTemp}*C | Max. temp: {maxTemp}*C",
      display.GetDisplayText()
    );
  }
}