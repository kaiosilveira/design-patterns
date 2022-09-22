using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Glyphs;

public class Glyph
{
  private readonly string character;
  private readonly string unicodeValue;
  private string name;

  public Glyph(string character, string unicodeValue, string name)
  {
    this.character = character;
    this.unicodeValue = unicodeValue;
    this.name = name;
  }

  public void Display(int x, int y, Window window)
  {
    window.Add(x, y, this.character);
  }

  public virtual int GetHeight()
  {
    return 1;
  }

  public virtual string GetChar()
  {
    return this.character;
  }

  public virtual string GetUnicodeValue()
  {
    return this.unicodeValue;
  }

  public virtual string GetName()
  {
    return this.name;
  }
}
