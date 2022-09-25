using Xunit;
using Moq;
using System;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Utils;

namespace HouseOfTheFuture.DomainTests;

public class SprinklerTest
{
  [Fact]
  public void TestDescribesTheCurrentSetup()
  {
    var mockedMediator = new Mock<WidgetMediator>();
    var mockedSchedule = new Mock<Schedule>();
    mockedSchedule.Setup(s => s.Describe()).Returns("Saturday: 07:00 | Sunday: 07:00");

    var sprinkler = new ConcreteSprinkler(mediator: mockedMediator.Object);
    sprinkler.SetSchedule(schedule: mockedSchedule.Object);

    Assert.Equal("Saturday: 07:00 | Sunday: 07:00", sprinkler.Describe());
  }

  [Fact]
  public void TestEmitsIrrigationStartedIfScheduledTimeMatchesCurrentTime()
  {
    var mockedMediator = new Mock<WidgetMediator>();
    var mockedSchedule = new Mock<Schedule>();
    mockedSchedule.Setup(s => s.Matches(It.IsAny<DateTime>())).Returns(true);

    var sprinkler = new ConcreteSprinkler(mediator: mockedMediator.Object);
    sprinkler.SetSchedule(schedule: mockedSchedule.Object);

    sprinkler.CheckTime(DateTime.Now);

    mockedMediator.Verify(
      m => m.RegisterEvent(
        It.Is<ApplicationEvent>(e => e.Data == null && e.Type == ApplicationEventType.IRRIGATION_STARTED)
      ),
      Times.Once()
    );
  }
}