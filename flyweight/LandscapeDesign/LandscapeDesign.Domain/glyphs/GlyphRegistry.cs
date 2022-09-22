namespace LandscapeDesign.Domain.Glyphs;

public static class GlyphRegistry
{
  public static Dictionary<string, Glyph> GLYPHS = new Dictionary<string, Glyph>()
  {
    { "🟫", new Glyph(character: "🟫", unicodeValue: "U+1F7EB", name: "Brown Square") },
    { "⬜", new Glyph(character: "⬜", unicodeValue: "U+2B1C", name: "White Square") },
    { "🌳", new Glyph(character: "🌳", unicodeValue: "U+1F333", name: "Tree") },
    { "🏠", new Glyph(character: "🏠", unicodeValue: "U+1F3E0", name: "House") },
  };
}