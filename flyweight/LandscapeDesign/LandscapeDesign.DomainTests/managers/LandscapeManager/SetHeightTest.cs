using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

public class LandscapeManager_SetHeightTest
{
  public readonly ScreenRect DEFAULT_5x5_SCREEN_RECT = new ScreenRect(xLength: 5, yLength: 5);

  [Fact]
  public void TestChangesTheHeightOfGlyph()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_5x5_SCREEN_RECT);
    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS[SupportedGlyphs.TREE]);
    landscapeManager.SetHeight(x: 0, y: 0, height: 3);

    var updatedItem = landscapeManager.Inspect(x: 0, y: 0);

    Assert.Equal(3, updatedItem.GetHeight());
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightInInvalidScreenPosition()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_5x5_SCREEN_RECT);
    Assert.Throws<PixelOutOfBoundsException>(
      () => landscapeManager.SetHeight(x: 10, y: 10, height: 3)
    );
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightToDefaultGlyph()
  {
    var landscapeManager = new LandscapeManager(DEFAULT_5x5_SCREEN_RECT);
    Assert.Throws<DefaultGlyphNotEditableException>(
      () => landscapeManager.SetHeight(x: 0, y: 0, height: 3)
    );
  }
}