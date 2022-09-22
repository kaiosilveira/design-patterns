using LandscapeDesign.Domain.Glyphs;

namespace LandscapeDesign.Domain.Screens;

public interface Screen
{
  public void Add(int x, int y, string item);
  public void SetupDisplay(Glyph[][] scheme);
  public string[][] GetSymbolMap();
  public void Paint();
}