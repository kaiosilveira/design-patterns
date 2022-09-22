using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;

public class LandscapeManager_InspectTest
{
  [Fact]
  public void TestInspectGlyph()
  {
    var glyph = GlyphRegistry.GLYPHS["🌳"];
    var manager = new LandscapeManager(xSize: 1, ySize: 1);
    manager.Add(0, 0, glyph);

    var resultingGlyph = manager.Inspect(x: 0, y: 0);

    Assert.Equal(glyph.GetName(), resultingGlyph.GetName());
    Assert.Equal(glyph.GetChar(), resultingGlyph.GetChar());
    Assert.Equal(glyph.GetUnicodeValue(), resultingGlyph.GetUnicodeValue());
    Assert.Equal(glyph.GetHeight(), resultingGlyph.GetHeight());
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToInspectInexistentGlyph()
  {
    var manager = new LandscapeManager(xSize: 1, ySize: 1);
    Assert.Throws<GlyphNotFoundException>(() => manager.Inspect(0, 0));
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToInspectGlyphOutsideOfScreenBounds()
  {
    var manager = new LandscapeManager(xSize: 1, ySize: 1);
    Assert.Throws<PixelOutOfBoundsException>(() => manager.Inspect(5, 5));
  }
}