using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

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

    while (input != "q")
    {
      Console.Clear();
      Console.WriteLine("Interactive mode active. Press 'q' anytime to quit...");
      Console.WriteLine($"Last key typed: {input}");
      Console.WriteLine($"Current position: ({currentPositionX}, {currentPositionY})");
      var screen = new ConcreteScreen(xSize: numberOfRows, ySize: numberOfCols);
      var scheme = landscapeManager.GetGlyphMap();
      screen.SetupDisplay(scheme);
      screen.Paint();

      var key = Console.ReadKey().Key;
      if (key == ConsoleKey.RightArrow)
      {
        currentPositionY++;
      }

      if (key == ConsoleKey.LeftArrow)
      {
        currentPositionY--;
      }

      if (key == ConsoleKey.DownArrow)
      {
        currentPositionX++;
      }

      if (key == ConsoleKey.UpArrow)
      {
        currentPositionX--;
      }

      if (key == ConsoleKey.T)
      {
        landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS["🌳"]);
      }

      if (key == ConsoleKey.W)
      {
        landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS["⬜"]);
      }

      if (key == ConsoleKey.H)
      {
        landscapeManager.SetItem(x: currentPositionX, y: currentPositionY, GlyphRegistry.GLYPHS["🏠"]);
      }

      input = Convert.ToString(key);
    }
  }
}