using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Glyphs;

public interface Glyph
{
  public void Display(int x, int y, Screen screen);

  public string GetChar();

  public string GetUnicodeValue();

  public string GetName();
}