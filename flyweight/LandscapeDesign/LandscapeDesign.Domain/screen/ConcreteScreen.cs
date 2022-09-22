using LandscapeDesign.Domain.Glyphs;

namespace LandscapeDesign.Domain.Screens;

public class ConcreteScreen : Screen
{
  private string[][] symbolMap;

  public ConcreteScreen(int xSize, int ySize)
  {
    this.symbolMap = this.SetupSymbolMap(xSize, ySize);
  }

  public string[][] GetDrawingScheme()
  {
    return this.symbolMap;
  }

  public void Add(int x, int y, string item)
  {
    this.symbolMap[x][y] = item;
  }

  public void SetupDisplay(Glyph[][] glyphMap)
  {
    for (int i = 0; i < glyphMap.Length; i++)
    {
      var row = glyphMap[i];
      for (int j = 0; j < row.Length; j++)
      {
        var item = row[j];
        item.Display(x: i, y: j, this);
      }
    }
  }

  public void Paint()
  {
    for (int i = 0; i < this.symbolMap.Length; i++)
    {
      var row = this.symbolMap[i];
      for (int j = 0; j < row.Length; j++)
      {
        Console.Write(row[j]);
      }
      Console.Write("\n");
    }
  }

  private string[][] SetupSymbolMap(int xSize, int ySize)
  {
    var result = new string[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      result[i] = new string[ySize];
    }

    return result;
  }
}
