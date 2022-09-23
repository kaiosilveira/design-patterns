namespace LandscapeDesign.ConsoleApp;

public class EditItemView
{
  public ApplicationState appState;
  public EditItemView(ApplicationState appState)
  {
    this.appState = appState;
  }

  public ApplicationState Render()
  {
    Console.WriteLine("Edition mode active. Type 'q!' to go back to interactive mode");
    var landscapeManager = appState.landscapeManager;
    var currentPositionX = appState.currentPositionX;
    var currentPositionY = appState.currentPositionY;
    var currentView = appState.currentView;

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
      lastCommand: newName ?? appState.lastCommand,
      rect: appState.rect,
      currentView: TerminalViews.INTERACTIVE
    );
  }
}
