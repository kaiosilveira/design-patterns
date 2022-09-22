namespace LandscapeDesign.Domain.Managers;

public class GlyphNotFoundException : Exception
{
  public GlyphNotFoundException(int x, int y)
    : base(message: $"No glyph was found at ({x}, {y})")
  { }
}