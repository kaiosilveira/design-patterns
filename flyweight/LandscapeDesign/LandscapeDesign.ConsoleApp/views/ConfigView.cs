using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.ConsoleApp;

class ConfigView
{
  public ApplicationState Render()
  {
    Console.WriteLine("Welcome to the LandscapeDesign app. Let's start by defining the size of your landscape");
    Console.Write("X axis size:");
    var numberOfCols = Convert.ToInt32(Console.ReadLine());
    Console.Write("Y axis size:");
    var numberOfRows = Convert.ToInt32(Console.ReadLine());

    var landscapeManager = new LandscapeManager(
      new ScreenRect(xLength: numberOfRows, yLength: numberOfCols)
    );

    return new ApplicationState(
      landscapeManager,
      currentPosX: 0,
      currentPosY: 0,
      lastCommand: "",
      rect: new ScreenRect(xLength: numberOfRows, yLength: numberOfCols),
      currentView: TerminalViews.INTERACTIVE
    );
  }
}