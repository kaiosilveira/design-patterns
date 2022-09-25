using System.ComponentModel;
using HouseOfTheFuture.Domain.Utils;
using HouseOfTheFuture.Domain.Widgets;

public class Program
{
  static BackgroundWorker keyListenerWorker = new BackgroundWorker();
  static ApplicationState appState = new ApplicationState(currentView: ViewTypes.MAIN, lastCommand: "");

  public static void Main(string[] args)
  {
    keyListenerWorker.DoWork += KeyListenerWorker_DoWork;
    keyListenerWorker.RunWorkerCompleted += KeyListenerWorker_RunWorkerCompleted;
    keyListenerWorker.RunWorkerAsync();

    var mediator = new ConcreteWidgetMediator();
    ConcreteAlarm alarm = new ConcreteAlarm(mediator);
    ConcreteWeatherMonitor weatherMonitor = new ConcreteWeatherMonitor(mediator);
    ConcreteClock clock = new ConcreteClock(mediator);
    ConcreteDisplay display = new ConcreteDisplay(mediator);
    ConcreteCalendar calendar = new ConcreteCalendar(mediator);
    CoffeePot coffeePot = new ConcreteCoffeePot(mediator, timeProvider: new ConcreteTimeProvider());

    mediator.AddWidget(alarm);
    mediator.AddWidget(clock);
    mediator.AddWidget(display);
    mediator.AddWidget(weatherMonitor);
    mediator.AddWidget(coffeePot);

    weatherMonitor.SetTemperature(21);

    var now = DateTime.Now;
    var daysOfWeek = new List<DayOfWeek>() { DayOfWeek.Saturday, DayOfWeek.Sunday };
    alarm.SetSchedule(new WeeklySchedule(daysOfWeek, now.Hour, now.Minute, now.Second + 2));

    while (true)
    {
      Thread.Sleep(100);
      clock.Tick();
      if (appState.CurrentView == ViewTypes.MAIN) appState = new MainView(appState).Render(clock, display);
      if (appState.CurrentView == ViewTypes.ADD_EVENT) appState = new AddEventView(appState).Render(calendar);
    }
  }

  private static void KeyListenerWorker_DoWork(object? sender, DoWorkEventArgs e)
  {
    if (Console.KeyAvailable == false)
    {
      System.Threading.Thread.Sleep(100);
    }
    else
    {
      var keyInfo = Console.ReadKey();
      if (keyInfo.Key == ConsoleKey.E)
      {
        appState = new ApplicationState(
          currentView: ViewTypes.ADD_EVENT, lastCommand: keyInfo.Key.ToString()
        );
      }
    }
  }

  private static void KeyListenerWorker_RunWorkerCompleted(object? sender, RunWorkerCompletedEventArgs args)
  {
    if (!keyListenerWorker.IsBusy)
    {
      keyListenerWorker.RunWorkerAsync();
    }
  }
}