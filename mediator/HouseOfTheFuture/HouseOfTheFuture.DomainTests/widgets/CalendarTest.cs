using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;

public class ClockTest
{
  [Fact]
  public void TestEmitsEventOnTick()
  {
    var mockedMediatorWrapper = new Mock<Mediator>();
    var clock = new Clock(mediator: mockedMediatorWrapper.Object);

    clock.Tick();

    mockedMediatorWrapper.Verify(
      m => m.RegisterEvent(ApplicationEventType.CLOCK_TICK),
      Times.Once()
    );
  }
}