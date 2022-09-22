using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

public class Program
{
  public static void Main(string[] args)
  {
    var numberOfRows = 26;
    var numberOfCols = 26;
    var landscapeManager = new LandscapeManager(
      new ScreenRect(xLength: numberOfRows, yLength: numberOfCols)
    );

    for (int i = 0; i < numberOfRows; i++)
    {
      for (int j = 0; j < numberOfCols; j++)
      {
        landscapeManager.Add(x: i, y: j, GlyphRegistry.GLYPHS["🌳"]);
      }
    }

    landscapeManager.Add(
      x: (numberOfRows - 1) / 2,
      y: (numberOfCols - 1) / 2,
      GlyphRegistry.GLYPHS["🏠"]
    );

    var screen = new ConcreteScreen(xSize: numberOfRows, ySize: numberOfCols);
    var scheme = landscapeManager.GetDrawingScheme();
    screen.SetScheme(scheme);
    screen.Paint();
  }
}