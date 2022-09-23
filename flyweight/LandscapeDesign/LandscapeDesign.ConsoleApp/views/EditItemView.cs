namespace LandscapeDesign.ConsoleApp;

public class EditItemView : TerminalView
{
  public ApplicationState appState;
  public EditItemView(ApplicationState appState)
  {
    this.appState = appState;
  }

  public ApplicationState Render()
  {
    Console.WriteLine("Edition mode active. Type 'q!' to go back to interactive mode");
    var landscapeManager = appState.LandscapeManager;
    var currentPositionX = appState.CurrentPositionX;
    var currentPositionY = appState.CurrentPositionY;
    var currentView = appState.CurrentView;

    var currentGlyph = landscapeManager.Inspect(x: currentPositionX, y: currentPositionY);
    Console.WriteLine($"Current editing {currentGlyph.GetName()} at ({currentPositionX}, {currentPositionY})");
    Console.WriteLine($"Item: {currentGlyph.GetName()}");
    var newName = Console.ReadLine();
    if (newName != "\n" && newName != "q!")
    {
      landscapeManager.SetName(x: currentPositionX, y: currentPositionY, name: newName ?? currentGlyph.GetName());
    }

    Console.WriteLine($"Instance: {currentGlyph.GetType().Name}");
    Console.WriteLine($"Height: {currentGlyph.GetHeight()}");

    return new ApplicationState(
      landscapeManager,
      currentPositionX,
      currentPositionY,
      lastCommand: newName ?? appState.LastCommand,
      rect: appState.Rect,
      currentView: TerminalViews.INTERACTIVE
    );
  }
}
