using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Glyphs;

public interface Glyph
{
  public void Display(int x, int y, Window window);

  public int GetHeight();

  public string GetChar();

  public string GetUnicodeValue();

  public string GetName();
}