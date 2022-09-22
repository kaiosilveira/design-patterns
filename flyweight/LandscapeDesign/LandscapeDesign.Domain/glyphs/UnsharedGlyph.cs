namespace LandscapeDesign.Domain.Glyphs;

public class UnsharedGlyph : Glyph
{
  private int height;

  public UnsharedGlyph(string character, string unicodeValue, string description, int height) : base(character, unicodeValue, description)
  {
    this.height = height;
  }

  public override int GetHeight()
  {
    return this.height;
  }
}
