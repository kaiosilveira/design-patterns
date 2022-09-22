using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;

public class LandscapeManager_SetHeightTest
{
  [Fact]
  public void TestChangesTheHeightOfGlyph()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.SetHeight(x: 0, y: 0, height: 3);

    var updatedItem = landscapeManager.Inspect(x: 0, y: 0);

    Assert.Equal(3, updatedItem.GetHeight());
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightInInvalidScreenPosition()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    Assert.Throws<PixelOutOfBoundsException>(
      () => landscapeManager.SetHeight(x: 10, y: 10, height: 3)
    );
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightToAnInexistentGlyph()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    Assert.Throws<GlyphNotFoundException>(
      () => landscapeManager.SetHeight(x: 0, y: 0, height: 3)
    );
  }
}