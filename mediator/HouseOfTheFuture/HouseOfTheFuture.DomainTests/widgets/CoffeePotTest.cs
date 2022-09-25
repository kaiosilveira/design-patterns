using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;

public class CoffeePotTest
{
  [Fact]
  public void TestStartBrewing()
  {
    var mockedMediator = new Mock<Mediator>();
    var mockedTimeProvider = new Mock<TimeProvider>();
    mockedTimeProvider.Setup(tp => tp.GetCurrentDateTime()).Returns(DateTime.Now);

    var coffeePot = new ConcreteCoffeePot(
      mediator: mockedMediator.Object,
      timeProvider: mockedTimeProvider.Object
    );

    coffeePot.StartBrewing();

    Assert.True(coffeePot.IsBrewing);
  }

  [Fact]
  public void NotifiesCoffeeReadyAfterTwentySecondsOfBrewing()
  {
    var date = DateTime.Now;
    var mockedMediator = new Mock<Mediator>();
    var mockedTimeProvider = new Mock<TimeProvider>();
    mockedTimeProvider.Setup(tp => tp.GetCurrentDateTime()).Returns(date);
    mockedTimeProvider
      .Setup(tp => tp.Compare(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
      .Returns(true);

    var coffeePot = new ConcreteCoffeePot(
      mediator: mockedMediator.Object, timeProvider: mockedTimeProvider.Object
    );

    coffeePot.StartBrewing();
    coffeePot.CheckTime(date.AddSeconds(20));

    mockedMediator
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