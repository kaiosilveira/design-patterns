using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;

public class LandscapeManager_SetNameTest
{
  [Fact]
  public void TestChangesTheNameOfGlyph()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.SetName(x: 0, y: 0, name: "My special tree");

    var updatedItem = landscapeManager.Inspect(x: 0, y: 0);

    Assert.Equal("My special tree", updatedItem.GetName());
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightInInvalidScreenPosition()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    Assert.Throws<PixelOutOfBoundsException>(
      () => landscapeManager.SetName(x: 10, y: 10, name: "My special tree")
    );
  }

  [Fact]
  public void TestThrowsExceptionIfTryingToSetHeightToAnInexistentGlyph()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    Assert.Throws<GlyphNotFoundException>(
      () => landscapeManager.SetName(x: 0, y: 0, name: "My special tree")
    );
  }
}