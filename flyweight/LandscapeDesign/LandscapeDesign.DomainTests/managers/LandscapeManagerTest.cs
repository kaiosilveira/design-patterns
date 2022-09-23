using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

namespace LandscapeDesign.DomainTests;

public class LandscapeManagerTest
{
  public readonly ScreenRect DEFAULT_1x1_SCREEN_RECT = new ScreenRect(xLength: 1, yLength: 1);

  [Fact]
  public void TestThrowsAnErrorIfMatrixWouldContainWidthZero()
  {
    Assert.Throws<InvalidMatrixBoundsException>(
      () => new LandscapeManager(new ScreenRect(xLength: 0, yLength: 1))
    );
  }

  [Fact]
  public void TestThrowsAnErrorIfMatrixWouldContainHeightZero()
  {
    Assert.Throws<InvalidMatrixBoundsException>(
      () => new LandscapeManager(new ScreenRect(xLength: 1, yLength: 0))
    );
  }

  [Fact]
  public void TestReturnsBrownSquaresIfNothingWasAdded()
  {
    var manager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    var scheme = manager.GetGlyphMap();
    Assert.Equal(GlyphRegistry.GLYPHS[SupportedGlyphs.BROWN_SQUARE], scheme[0][0]);
  }

  [Fact]
  public void TestAddsGlyphToScheme()
  {
    var glyph = GlyphRegistry.GLYPHS[SupportedGlyphs.TREE];
    var manager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    manager.Add(x: 0, y: 0, glyph);

    var scheme = manager.GetGlyphMap();

    Assert.Equal(glyph, scheme[0][0]);
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToAddGlyphToInexistentPosition()
  {
    var glyph = GlyphRegistry.GLYPHS[SupportedGlyphs.TREE];
    var manager = new LandscapeManager(new ScreenRect(xLength: 1, yLength: 1));
    Assert.Throws<PixelOutOfBoundsException>(() => manager.Add(5, 5, glyph));
  }

  [Fact]
  public void TestConvertsGlyphToUnsharedIfCustomPropertiesAreAdded()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);

    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS[SupportedGlyphs.TREE]);

    landscapeManager.SetHeight(x: 0, y: 0, height: 3);
    landscapeManager.SetName(x: 0, y: 0, name: "My special tree");

    var updatedItem = landscapeManager.Inspect(x: 0, y: 0);

    Assert.IsType<UnsharedGlyph>(updatedItem);
    Assert.Equal(3, updatedItem.GetHeight());
    Assert.Equal("My special tree", updatedItem.GetName());
  }
}
