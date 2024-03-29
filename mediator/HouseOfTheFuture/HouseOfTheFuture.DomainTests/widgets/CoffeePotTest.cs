using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

public class CoffeePotTest
{
  [Fact]
  public void TestStartBrewing()
  {
    var widgetHub = new Mock<WidgetHub>();
    var timeProvider = new Mock<TimeProvider>();
    timeProvider.Setup(tp => tp.GetCurrentDateTime()).Returns(DateTime.Now);

    var coffeePot = new ConcreteCoffeePot(
      mediator: widgetHub.Object,
      timeProvider: timeProvider.Object
    );

    coffeePot.StartBrewing();

    Assert.True(coffeePot.IsBrewing);
  }

  [Fact]
  public void NotifiesCoffeeReadyAfterTwentySecondsOfBrewing()
  {
    var date = DateTime.Now;
    var widgetHub = new Mock<WidgetHub>();
    var timeProvider = new Mock<TimeProvider>();
    timeProvider.Setup(tp => tp.GetCurrentDateTime()).Returns(date);
    timeProvider
      .Setup(tp => tp.Compare(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
      .Returns(true);

    var coffeePot = new ConcreteCoffeePot(
      mediator: widgetHub.Object, timeProvider: timeProvider.Object
    );

    coffeePot.StartBrewing();
    coffeePot.CheckTime(date.AddSeconds(20));

    widgetHub
      .Verify(m => m
        .RegisterEvent(
          It.Is<ApplicationEvent>(
            e => e.Data == null && e.Type == ApplicationEventType.COFFEE_READY
          )
        ),
        Times.Once()
      );
  }
}