using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

public class LandscapeManager_SetNameTest
{
  public readonly ScreenRect DEFAULT_1x1_SCREEN_RECT = new ScreenRect(xLength: 1, yLength: 1);

  [Fact]
  public void TestChangesTheNameOfGlyph()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS[SupportedGlyphs.TREE]);
    landscapeManager.SetName(x: 0, y: 0, name: "My special tree");

    var updatedItem = landscapeManager.Inspect(x: 0, y: 0);

    Assert.Equal("My special tree", updatedItem.GetName());
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightInInvalidScreenPosition()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    Assert.Throws<PixelOutOfBoundsException>(
      () => landscapeManager.SetName(x: 10, y: 10, name: "My special tree")
    );
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightToAnInexistentGlyph()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_1x1_SCREEN_RECT);
    Assert.Throws<GlyphNotFoundException>(
      () => landscapeManager.SetName(x: 0, y: 0, name: "My special tree")
    );
  }
}