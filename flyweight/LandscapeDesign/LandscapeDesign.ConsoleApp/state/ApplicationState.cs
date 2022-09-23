using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.ConsoleApp;

public class ApplicationState
{
  public readonly int currentPositionX;
  public readonly int currentPositionY;
  public readonly string lastCommand;
  public readonly TerminalViews currentView;
  public readonly LandscapeManager landscapeManager;
  public readonly ScreenRect rect;

  public ApplicationState(
    LandscapeManager landscapeManager,
    int currentPosX,
    int currentPosY,
    string lastCommand,
    ScreenRect rect,
    TerminalViews currentView
  )
  {
    this.landscapeManager = landscapeManager;
    this.currentPositionX = currentPosX;
    this.currentPositionY = currentPosY;
    this.rect = rect;
    this.currentView = currentView;
    this.lastCommand = lastCommand;
  }
}
