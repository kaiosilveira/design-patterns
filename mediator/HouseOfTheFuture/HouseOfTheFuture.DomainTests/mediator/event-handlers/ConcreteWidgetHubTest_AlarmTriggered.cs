using Xunit;
using Moq;
using HouseOfTheFuture.Domain.Events;
using HouseOfTheFuture.Domain.Widgets;
using HouseOfTheFuture.Domain.Exceptions;

public class ConcreteWidgetHubTest_AlarmTriggered
{
  [Fact]
  public void TestThrowsExceptionIfNoCoffeePotWasRegistered()
  {
    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetHub();

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestStartsTheBrewingProcessOnCoffeePot()
  {
    var coffeePot = new Mock<CoffeePot>();
    var display = new Mock<Display>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(coffeePot.Object);
    mediator.AddWidget(display.Object);

    mediator.RegisterEvent(e);

    coffeePot.Verify(cp => cp.StartBrewing(), Times.Once());
  }

  [Fact]
  public void TestThrowsExceptionIfNoDisplayWasRegistered()
  {
    var coffeePot = new Mock<CoffeePot>();

    var e = new ApplicationEvent(data: null, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(coffeePot.Object);

    Assert.Throws<WidgetNotRegisteredException>(() => mediator.RegisterEvent(e));
  }

  [Fact]
  public void TestDisplaysGoodMorningMessage()
  {
    var display = new Mock<Display>();
    var coffeePot = new Mock<CoffeePot>();
    var alarmText = "It's Friday, 09:00!";
    var e = new ApplicationEvent(data: alarmText, type: ApplicationEventType.ALARM_TRIGGERED);
    var mediator = new ConcreteWidgetHub();
    mediator.AddWidget(display.Object);
    mediator.AddWidget(coffeePot.Object);

    mediator.RegisterEvent(e);

    display.Verify(cp => cp.NotifyAlarmTriggered(alarmText), Times.Once());
  }
}