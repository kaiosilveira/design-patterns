using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Exceptions;

public class ConcreteWidgetHubTest
{
  [Fact]
  public void TestGetWidgetCount_ReturnsZeroIfWidgetListIsEmpty()
  {
    var mediator = new ConcreteWidgetHub();
    Assert.Equal(0, mediator.GetWidgetCount());
  }

  [Fact]
  public void TestAddWidget()
  {
    var alarm = new Mock<Alarm>();
    var mediator = new ConcreteWidgetHub();

    mediator.AddWidget(widget: alarm.Object);

    Assert.Equal(1, mediator.GetWidgetCount());
  }

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