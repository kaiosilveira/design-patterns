using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;

public class ClockTest
{
  [Fact]
  public void TestEmitsEventOnTick()
  {
    var mockedMediatorWrapper = new Mock<WidgetMediator>();
    var clock = new ConcreteClock(mediator: mockedMediatorWrapper.Object);

    clock.Tick();

    mockedMediatorWrapper.Verify(
      m => m.RegisterEvent(
        It.Is<ApplicationEvent>(e => e.Type == ApplicationEventType.CLOCK_TICK)
      ),
      Times.Once()
    );
  }
}