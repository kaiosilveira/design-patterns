using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.ConsoleApp;

public class ApplicationState
{
  public readonly int CurrentPositionX;
  public readonly int CurrentPositionY;
  public readonly string LastCommand;
  public readonly TerminalViews CurrentView;
  public readonly LandscapeManager LandscapeManager;
  public readonly ScreenRect Rect;

  public ApplicationState(
    LandscapeManager landscapeManager,
    int currentPosX,
    int currentPosY,
    string lastCommand,
    ScreenRect rect,
    TerminalViews currentView
  )
  {
    this.LandscapeManager = landscapeManager;
    this.CurrentPositionX = currentPosX;
    this.CurrentPositionY = currentPosY;
    this.Rect = rect;
    this.CurrentView = currentView;
    this.LastCommand = lastCommand;
  }
}
