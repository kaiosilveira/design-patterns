namespace LandscapeDesign.Domain.Glyphs;

public static class GlyphRegistry
{
  public static Dictionary<string, FlyweightGlyph> GLYPHS = new Dictionary<string, FlyweightGlyph>()
  {
    { "🟫", new FlyweightGlyph(character: "🟫", unicodeValue: "U+1F7EB", name: "Brown Square") },
    { "⬜", new FlyweightGlyph(character: "⬜", unicodeValue: "U+2B1C", name: "White Square") },
    { "🌳", new FlyweightGlyph(character: "🌳", unicodeValue: "U+1F333", name: "Tree") },
    { "🏠", new FlyweightGlyph(character: "🏠", unicodeValue: "U+1F3E0", name: "House") },
  };
}