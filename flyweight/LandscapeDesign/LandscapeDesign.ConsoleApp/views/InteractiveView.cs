using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.ConsoleApp;

public class InteractiveView
{
  private readonly ApplicationState appState;

  public InteractiveView(ApplicationState appState)
  {
    this.appState = appState;
  }

  public ApplicationState Render()
  {
    var landscapeManager = appState.landscapeManager;
    var currentPositionX = appState.currentPositionX;
    var currentPositionY = appState.currentPositionY;
    var numberOfRows = appState.rect.XLength;
    var numberOfCols = appState.rect.YLength;

    var input = appState.lastCommand;
    Console.WriteLine("Interactive mode active. Press 'q' anytime to quit...");
    Console.WriteLine($"Last key typed: {input}");
    Console.WriteLine($"Current position: ({currentPositionX}, {currentPositionY})");

    var screen = new ConcreteScreen(xSize: numberOfRows, ySize: numberOfCols);
    var scheme = landscapeManager.GetGlyphMap();

    screen.SetupDisplay(scheme);
    screen.Paint();

    var currentGlyph = landscapeManager.Inspect(x: currentPositionX, y: currentPositionY);
    Console.WriteLine($"Item: {currentGlyph.GetName()}");
    Console.WriteLine($"Instance: {currentGlyph.GetType().Name}");
    Console.WriteLine($"Height: {currentGlyph.GetHeight()}");

    var key = Console.ReadKey().Key;
    input = Convert.ToString(key);

    if (key == ConsoleKey.RightArrow && currentPositionY < numberOfCols - 1)
    {
      currentPositionY++;
    }

    if (key == ConsoleKey.LeftArrow && currentPositionY > 0)
    {
      currentPositionY--;
    }

    if (key == ConsoleKey.DownArrow && currentPositionX < numberOfRows - 1)
    {
      currentPositionX++;
    }

    if (key == ConsoleKey.UpArrow && currentPositionX > 0)
    {
      currentPositionX--;
    }

    if (key == ConsoleKey.T)
    {
      landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS[SupportedGlyphs.TREE]);
    }

    if (key == ConsoleKey.W)
    {
      landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS[SupportedGlyphs.WHITE_SQUARE]);
    }

    if (key == ConsoleKey.B)
    {
      landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS[SupportedGlyphs.BROWN_SQUARE]);
    }

    if (key == ConsoleKey.H)
    {
      landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS[SupportedGlyphs.HOUSE]);
    }

    var currentView = appState.currentView;
    if (key == ConsoleKey.E)
    {
      currentView = TerminalViews.EDIT_ITEM;
    }

    return new ApplicationState(
      landscapeManager,
      currentPositionX,
      currentPositionY,
      lastCommand: input ?? appState.lastCommand,
      rect: appState.rect,
      currentView
    );
  }
}
