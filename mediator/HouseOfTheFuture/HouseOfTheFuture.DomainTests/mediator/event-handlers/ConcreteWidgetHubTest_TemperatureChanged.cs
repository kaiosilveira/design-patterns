using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Exceptions;

public class ConcreteWidgetHubTest_TemperatureChanged
{
  [Fact]
  public void TestThrowsExceptionIfDisplayWidgetIsNotRegistered()
  {
    var newTemperature = 35;
    var e = new ApplicationEvent(
      data: newTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetHub();
    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestThrowsExceptionIfNewTemperatureIsInvalid()
  {
    var display = new Mock<Display>();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);

    Assert.Throws<InvalidCastException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestThrowsExceptionIfNewTemperatureIsNotInteger()
  {
    var display = new Mock<Display>();
    var e = new ApplicationEvent(
      data: "invalid integer", type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);

    Assert.Throws<FormatException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestUpdatesDisplay()
  {
    var newTemperature = 35;
    var display = new Mock<Display>();
    var e = new ApplicationEvent(
      data: newTemperature, type: ApplicationEventType.TEMPERATURE_CHANGED
    );

    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    display.Verify(d => d.SetCurrentTemperature(It.IsAny<int>()), Times.Once());
  }
}