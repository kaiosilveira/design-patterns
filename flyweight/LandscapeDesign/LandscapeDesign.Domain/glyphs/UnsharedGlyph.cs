using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Glyphs;

public class UnsharedGlyph : Glyph
{
  private int height;
  private string character;
  private string unicodeValue;
  private string name;

  public UnsharedGlyph(string character, string unicodeValue, string name, int height)
  {
    this.height = height;
    this.unicodeValue = unicodeValue;
    this.name = name;
    this.height = height;
    this.character = character;
  }

  public void Display(int x, int y, Window window)
  {
    window.Add(x, y, this.character);
  }

  public string GetChar()
  {
    return this.character;
  }

  public int GetHeight()
  {
    return this.height;
  }

  public string GetName()
  {
    return this.name;
  }

  public string GetUnicodeValue()
  {
    return this.unicodeValue;
  }
}
