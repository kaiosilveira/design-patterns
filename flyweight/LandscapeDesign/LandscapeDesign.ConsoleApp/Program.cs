using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    Console.WriteLine("Welcome to the LandscapeDesign app. Let's start by defining the size of your landscape");
    Console.Write("X axis size:");
    var numberOfCols = Convert.ToInt32(Console.ReadLine());
    Console.Write("Y axis size:");
    var numberOfRows = Convert.ToInt32(Console.ReadLine());

    var landscapeManager = new LandscapeManager(
      new ScreenRect(xLength: numberOfRows, yLength: numberOfCols)
    );

    var appState = new ApplicationState(
      landscapeManager,
      currentPosX: 0,
      currentPosY: 0,
      lastCommand: "",
      rect: new ScreenRect(xLength: numberOfRows, yLength: numberOfCols),
      currentView: TerminalViews.INTERACTIVE
    );

    while (appState.lastCommand != "q")
    {
      Console.Clear();
      switch (appState.currentView)
      {
        case TerminalViews.EDIT_ITEM:
          appState = new EditItemView(appState).Render();
          break;
        case TerminalViews.INTERACTIVE:
          appState = new InteractiveView(appState).Render();
          break;
        default:
          break;
      }
    }
  }
}