using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;

namespace LandscapeDesign.DomainTests;

public class LandscapeManagerTest
{
  [Fact]
  public void TestThrowsAnErrorIfMatrixWouldContainSizeZero()
  {
    Assert.Throws<InvalidMatrixBoundsException>(() => new LandscapeManager(xSize: 0, ySize: 0));
  }

  [Fact]
  public void TestReturnsAnEmptyMatrixIfNothingWasAdded()
  {
    var manager = new LandscapeManager(xSize: 1, ySize: 1);
    var scheme = manager.GetDrawingScheme();
    Assert.Null(scheme[0][0]);
  }

  [Fact]
  public void TestAddsGlyphToScheme()
  {
    var glyph = GlyphRegistry.GLYPHS["🌳"];
    var manager = new LandscapeManager(xSize: 1, ySize: 1);
    manager.Add(0, 0, glyph);

    var scheme = manager.GetDrawingScheme();

    Assert.Equal(glyph, scheme[0][0]);
  }

  [Fact]
  public void TestDescribesGlyph()
  {
    var glyph = GlyphRegistry.GLYPHS["🌳"];
    var manager = new LandscapeManager(xSize: 1, ySize: 1);
    manager.Add(0, 0, glyph);

    var scheme = manager.GetDrawingScheme();
    var resultingGlyph = scheme[0][0];

    Assert.Equal(glyph.GetName(), resultingGlyph.GetName());
    Assert.Equal(glyph.GetChar(), resultingGlyph.GetChar());
    Assert.Equal(glyph.GetUnicodeValue(), resultingGlyph.GetUnicodeValue());
    Assert.Equal(glyph.GetHeight(), resultingGlyph.GetHeight());
  }

  [Fact]
  public void TestChangesTheHeightOfGlyph()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.SetHeight(x: 0, y: 0, height: 3);

    var updatedItem = landscapeManager.Describe(x: 0, y: 0);

    Assert.Equal(3, updatedItem.GetHeight());
  }

  [Fact]
  public void TestChangesTheNameOfGlyph()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);
    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.SetName(x: 0, y: 0, name: "My special tree");

    var updatedItem = landscapeManager.Describe(x: 0, y: 0);

    Assert.Equal("My special tree", updatedItem.GetName());
  }

  [Fact]
  public void TestConvertsGlyphToUnsharedIfCustomPropertiesAreAdded()
  {
    var landscapeManager = new LandscapeManager(xSize: 5, ySize: 5);

    landscapeManager.Add(0, 0, GlyphRegistry.GLYPHS["🌳"]);

    landscapeManager.SetHeight(x: 0, y: 0, height: 3);
    landscapeManager.SetName(x: 0, y: 0, name: "My special tree");

    var updatedItem = landscapeManager.Describe(x: 0, y: 0);

    Assert.IsType<UnsharedGlyph>(updatedItem);
    Assert.Equal(3, updatedItem.GetHeight());
    Assert.Equal("My special tree", updatedItem.GetName());
  }
}