using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Managers;

public class LandscapeManager
{
  private readonly int xSize;
  private readonly int ySize;
  private readonly ScreenRect screenRect;
  private Glyph[][] matrix;

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
    var unsharedGlyph = UnsharedGlyph.FromExisting(baseGlyph, name, baseGlyph.GetHeight());
    this.matrix[x][y] = unsharedGlyph;
  }

  public void SetHeight(int x, int y, int height)
  {
    this.ValidateScreenCoords(x, y);
    var baseGlyph = this.matrix[x][y] ?? throw new GlyphNotFoundException(x, y);
    var unsharedGlyph = UnsharedGlyph.FromExisting(baseGlyph, name: null, height);
    this.matrix[x][y] = unsharedGlyph;
  }

  public Glyph Inspect(int x, int y)
  {
    this.ValidateScreenCoords(x, y);
    return this.matrix[x][y] ?? throw new GlyphNotFoundException(x, y);
  }

  private Glyph[][] SetupMatrix(int xSize, int ySize)
  {
    var result = new Glyph[ySize][];

    for (int i = 0; i < xSize; i++)
    {
      result[i] = new Glyph[ySize];
    }

    return result;
  }

  private void ValidateScreenCoords(int x, int y)
  {
    if (this.xSize < x || this.ySize < y)
    {
      throw new PixelOutOfBoundsException(x, y);
    }
  }
}