using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Exceptions;

public class ConcreteWidgetHubTest_CoffeeReady
{
  [Fact]
  public void TestCoffeeIsReady_ThrowsExceptionIfThereAreNoDisplaysRegistered()
  {
    var mediator = new ConcreteWidgetHub();
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.COFFEE_READY
    );

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestCoffeeIsReady_CreatesDisplayNotification()
  {
    var display = new Mock<Display>();
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);
    var e = new ApplicationEvent(
      data: null, type: ApplicationEventType.COFFEE_READY
    );

    mediator.RegisterEvent(e);

    display.Verify(d => d.NotifyCoffeeReady(), Times.Once());
  }
}