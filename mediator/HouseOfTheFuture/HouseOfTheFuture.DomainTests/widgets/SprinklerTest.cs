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
    var widgetHub = new Mock<WidgetHub>();
    var schedule = new Mock<Schedule>();
    schedule.Setup(s => s.Describe()).Returns("Saturday: 07:00 | Sunday: 07:00");

    var sprinkler = new ConcreteSprinkler(mediator: widgetHub.Object);
    sprinkler.SetSchedule(schedule: schedule.Object);

    Assert.Equal("Saturday: 07:00 | Sunday: 07:00", sprinkler.Describe());
  }

  [Fact]
  public void TestEmitsIrrigationStartedIfScheduledTimeMatchesCurrentTime()
  {
    var widgetHub = new Mock<WidgetHub>();
    var schedule = new Mock<Schedule>();
    schedule.Setup(s => s.Matches(It.IsAny<DateTime>())).Returns(true);

    var sprinkler = new ConcreteSprinkler(mediator: widgetHub.Object);
    sprinkler.SetSchedule(schedule: schedule.Object);

    sprinkler.CheckTime(DateTime.Now);

    widgetHub.Verify(
      m => m.RegisterEvent(
        It.Is<ApplicationEvent>(e => e.Data == null && e.Type == ApplicationEventType.IRRIGATION_STARTED)
      ),
      Times.Once()
    );
  }
}