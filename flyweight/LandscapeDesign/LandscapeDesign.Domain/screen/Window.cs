using LandscapeDesign.Domain.Glyphs;

namespace LandscapeDesign.Domain.Screens;

public class Window
{
  private string[][] matrix;

  public Window(int xSize, int ySize)
  {
    this.matrix = this.SetupMatrix(xSize, ySize);
  }

  public string[][] GetDrawingScheme()
  {
    return this.matrix;
  }

  public void Add(int x, int y, string item)
  {
    this.matrix[x][y] = item;
  }

  public void SetScheme(FlyweightGlyph[][] scheme)
  {
    for (int i = 0; i < scheme.Length; i++)
    {
      var row = scheme[i];
      for (int j = 0; j < row.Length; j++)
      {
        var item = row[j];
        item.Display(x: i, y: j, this);
      }
    }
  }

  public void Paint()
  {
    for (int i = 0; i < this.matrix.Length; i++)
    {
      var row = this.matrix[i];
      for (int j = 0; j < row.Length; j++)
      {
        Console.Write(row[j]);
      }
      Console.Write("\n");
    }
  }

  private string[][] SetupMatrix(int xSize, int ySize)
  {
    var temp = new string[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      temp[i] = new string[ySize];
    }

    return temp;
  }
}
