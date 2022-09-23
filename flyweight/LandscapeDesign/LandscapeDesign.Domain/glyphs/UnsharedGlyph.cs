using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.Domain.Glyphs;

public class UnsharedGlyph : Glyph
{
  private string character;
  private string unicodeValue;
  private string name;

  public UnsharedGlyph(string character, string unicodeValue, string name)
  {
    this.unicodeValue = unicodeValue;
    this.name = name;
    this.character = character;
  }

  public void Display(int x, int y, Screen screen)
  {
    screen.Add(x, y, this.character);
  }

  public string GetChar()
  {
    return this.character;
  }

  public string GetName()
  {
    return this.name;
  }

  public string GetUnicodeValue()
  {
    return this.unicodeValue;
  }

  public static Glyph FromExisting(Glyph glyph, string? name)
  {
    return new UnsharedGlyph(
      glyph.GetChar(),
      glyph.GetUnicodeValue(),
      name ?? glyph.GetName()
    );
  }
}
