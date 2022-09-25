using HouseOfTheFuture.Domain.ValueObjects;
using HouseOfTheFuture.Domain.Widgets;

public class AddEventView
{
  private ApplicationState appState;

  public AddEventView(ApplicationState appState)
  {
    this.appState = appState;
  }

  public ApplicationState Render(Calendar calendar)
  {
    Console.Clear();
    Console.WriteLine("Add new event");

    Console.Write("date:");
    var date = Convert.ToDateTime(Console.ReadLine());

    Console.Write("description:");
    var possiblyNullDescription = Console.ReadLine();
    var calendarEvent = new CalendarEvent(at: date, possiblyNullDescription ?? "");

    calendar.AddEvent(calendarEvent);

    return new ApplicationState(currentView: ViewTypes.MAIN, lastCommand: appState.LastCommand);
  }
}