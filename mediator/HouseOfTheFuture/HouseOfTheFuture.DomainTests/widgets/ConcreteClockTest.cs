using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;

public class ClockTest
{
  [Fact]
  public void TestEmitsEventOnTick()
  {
    var widgetHub = new Mock<WidgetHub>();
    var clock = new ConcreteClock(mediator: widgetHub.Object);

    clock.Tick();

    widgetHub.Verify(
      m => m.RegisterEvent(
        It.Is<ApplicationEvent>(e => e.Type == ApplicationEventType.CLOCK_TICK)
      ),
      Times.Once()
    );
  }
}