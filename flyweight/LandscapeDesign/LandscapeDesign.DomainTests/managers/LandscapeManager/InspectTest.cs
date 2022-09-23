using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

public class LandscapeManager_InspectTest
{
  public readonly ScreenRect DEFAULT_1x1_SCREEN_RECT = new ScreenRect(xLength: 1, yLength: 1);

  [Fact]
  public void TestInspectGlyph()
  {
    var glyph = GlyphRegistry.GLYPHS[SupportedGlyphs.TREE];
    var manager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    manager.Add(0, 0, glyph);

    var resultingGlyph = manager.Inspect(x: 0, y: 0);

    Assert.Equal(glyph.GetName(), resultingGlyph.GetName());
    Assert.Equal(glyph.GetChar(), resultingGlyph.GetChar());
    Assert.Equal(glyph.GetUnicodeValue(), resultingGlyph.GetUnicodeValue());
  }

  [Fact]
  public void TestReturnsBrownSquareIfTryingToInspectInexistentGlyph()
  {
    var manager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    Assert.Equal(GlyphRegistry.GLYPHS[SupportedGlyphs.BROWN_SQUARE], manager.Inspect(x: 0, y: 0));
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToInspectGlyphOutsideOfScreenBounds()
  {
    var manager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    Assert.Throws<PixelOutOfBoundsException>(() => manager.Inspect(x: 5, y: 5));
  }
}