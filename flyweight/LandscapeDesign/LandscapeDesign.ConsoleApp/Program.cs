using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

public enum TerminalViews
{
  CONFIG,
  INTERACTIVE,
  EDIT_ITEM
}

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

    Console.WriteLine("Cool, all set! 🏠");

    var input = "";
    var currentPositionX = 0;
    var currentPositionY = 0;
    var editMode = false;

    while (input?.ToLower() != "q")
    {
      Console.Clear();

      if (editMode)
      {
        Console.WriteLine("Edition mode active. Type 'q!' to go back to interactive mode");

        var currentGlyph = landscapeManager.Inspect(x: currentPositionX, y: currentPositionY);
        Console.WriteLine($"Current editing {currentGlyph.GetName()} at ({currentPositionX}, {currentPositionY})");
        Console.WriteLine($"Item: {currentGlyph.GetName()}");
        var newName = Console.ReadLine();
        if (newName != "\n" && newName != "q!")
        {
          landscapeManager.SetName(x: currentPositionX, y: currentPositionY, name: newName ?? currentGlyph.GetName());
        }

        if (newName == "q!")
        {
          editMode = false;
        }

        Console.WriteLine($"Instance: {currentGlyph.GetType().Name}");
        Console.WriteLine($"Height: {currentGlyph.GetHeight()}");
      }
      else
      {
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

        if (key == ConsoleKey.E)
        {
          editMode = true;
        }
      }
    }
  }
}