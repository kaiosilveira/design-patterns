using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Glyphs;

public class FlyweightGlyph : Glyph
{
  private readonly string character;
  private readonly string unicodeValue;
  private string name;

  public FlyweightGlyph(string character, string unicodeValue, string name)
  {
    this.character = character;
    this.unicodeValue = unicodeValue;
    this.name = name;
  }

  public void Display(int x, int y, Screen screen)
  {
    screen.Add(x, y, this.character);
  }

  public int GetHeight()
  {
    return 1;
  }

  public string GetChar()
  {
    return this.character;
  }

  public string GetUnicodeValue()
  {
    return this.unicodeValue;
  }

  public string GetName()
  {
    return this.name;
  }
}
