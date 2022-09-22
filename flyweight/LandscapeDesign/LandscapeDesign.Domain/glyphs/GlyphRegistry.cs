namespace LandscapeDesign.Domain.Glyphs;

public static class GlyphRegistry
{
  public static Dictionary<SupportedGlyphs, FlyweightGlyph> GLYPHS = new Dictionary<SupportedGlyphs, FlyweightGlyph>()
  {
    { SupportedGlyphs.BROWN_SQUARE, new FlyweightGlyph(character: "🟫", unicodeValue: "U+1F7EB", name: "Brown Square") },
    { SupportedGlyphs.WHITE_SQUARE, new FlyweightGlyph(character: "⬜", unicodeValue: "U+2B1C", name: "White Square") },
    { SupportedGlyphs.TREE, new FlyweightGlyph(character: "🌳", unicodeValue: "U+1F333", name: "Tree") },
    { SupportedGlyphs.HOUSE, new FlyweightGlyph(character: "🏠", unicodeValue: "U+1F3E0", name: "House") },
  };
}