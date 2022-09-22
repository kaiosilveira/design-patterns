using LandscapeDesign.Domain.Glyphs;

namespace LandscapeDesign.Domain.Screens;

public interface Window
{
  public void Add(int x, int y, string item);
  public void SetScheme(Glyph[][] scheme);
  public void Paint();
}