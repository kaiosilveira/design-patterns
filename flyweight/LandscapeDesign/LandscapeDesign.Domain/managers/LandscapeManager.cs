using LandscapeDesign.Domain.Glyphs;

namespace LandscapeDesign.Domain.Managers;

public class InvalidMatrixBoundsException : Exception
{
  public InvalidMatrixBoundsException()
    : base(message: "Invalid matrix size provided for Landscape Manager")
  { }
}

public class LandscapeManager
{
  private FlyweightGlyph[][] matrix;

  public LandscapeManager(int xSize, int ySize)
  {
    if (xSize == 0 || ySize == 0)
    {
      throw new InvalidMatrixBoundsException();
    }

    this.matrix = this.SetupMatrix(xSize, ySize);
  }

  public FlyweightGlyph[][] GetDrawingScheme()
  {
    return this.matrix;
  }

  public void Add(int x, int y, FlyweightGlyph item)
  {
    this.matrix[x][y] = item;
  }

  public void SetName(int x, int y, string name)
  {
    var baseGlyph = this.matrix[x][y];
    var unsharedGlyph = new UnsharedGlyph(baseGlyph.GetChar(), baseGlyph.GetUnicodeValue(), name, baseGlyph.GetHeight());
    this.matrix[x][y] = unsharedGlyph;
  }

  public void SetHeight(int x, int y, int height)
  {
    var baseGlyph = this.matrix[x][y];
    var unsharedGlyph = new UnsharedGlyph(baseGlyph.GetChar(), baseGlyph.GetUnicodeValue(), baseGlyph.GetName(), height);
    this.matrix[x][y] = unsharedGlyph;
  }

  public FlyweightGlyph Inspect(int x, int y)
  {
    return this.matrix[x][y];
  }

  private FlyweightGlyph[][] SetupMatrix(int xSize, int ySize)
  {
    var temp = new FlyweightGlyph[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      temp[i] = new FlyweightGlyph[ySize];
    }

    return temp;
  }
}