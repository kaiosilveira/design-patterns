using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Widgets;

public class ConcreteWidgetHubTest
{
  [Fact]
  public void TestGetWidgetCountReturnsZeroIfWidgetListIsEmpty()
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
}