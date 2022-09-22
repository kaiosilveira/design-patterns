using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Managers;

public class LandscapeManager
{
  private readonly int xSize;
  private readonly int ySize;
  private readonly ScreenRect screenRect;
  private Glyph[][] matrix;

  public LandscapeManager(int xSize, int ySize)
  {
    if (xSize == 0 || ySize == 0)
    {
      throw new InvalidMatrixBoundsException();
    }

    this.xSize = xSize;
    this.ySize = ySize;
    this.screenRect = new ScreenRect(xSize, ySize);
    this.matrix = this.SetupMatrix(xSize, ySize);
  }

  public LandscapeManager(ScreenRect rect)
  {
    this.screenRect = rect;

    if (rect.XLength == 0 || rect.YLength == 0)
    {
      throw new InvalidMatrixBoundsException();
    }

    this.screenRect = rect;
    this.xSize = rect.XLength;
    this.ySize = rect.YLength;
    this.matrix = this.SetupMatrix(xSize, ySize);
  }

  public Glyph[][] GetDrawingScheme()
  {
    return this.matrix;
  }

  public void Add(int x, int y, Glyph item)
  {
    this.ValidateScreenCoords(x, y);
    this.matrix[x][y] = item;
  }

  public void SetName(int x, int y, string name)
  {
    this.ValidateScreenCoords(x, y);
    var baseGlyph = this.matrix[x][y] ?? throw new GlyphNotFoundException(x, y);
    var unsharedGlyph = new UnsharedGlyph(baseGlyph.GetChar(), baseGlyph.GetUnicodeValue(), name, baseGlyph.GetHeight());
    this.matrix[x][y] = unsharedGlyph;
  }

  public void SetHeight(int x, int y, int height)
  {
    this.ValidateScreenCoords(x, y);
    var baseGlyph = this.matrix[x][y] ?? throw new GlyphNotFoundException(x, y);
    var unsharedGlyph = new UnsharedGlyph(baseGlyph.GetChar(), baseGlyph.GetUnicodeValue(), baseGlyph.GetName(), height);
    this.matrix[x][y] = unsharedGlyph;
  }

  public Glyph Inspect(int x, int y)
  {
    this.ValidateScreenCoords(x, y);
    return this.matrix[x][y] ?? throw new GlyphNotFoundException(x, y);
  }

  private Glyph[][] SetupMatrix(int xSize, int ySize)
  {
    var temp = new Glyph[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      temp[i] = new Glyph[ySize];
    }

    return temp;
  }

  private void ValidateScreenCoords(int x, int y)
  {
    if (this.xSize < x || this.ySize < y)
    {
      throw new PixelOutOfBoundsException(x, y);
    }
  }
}