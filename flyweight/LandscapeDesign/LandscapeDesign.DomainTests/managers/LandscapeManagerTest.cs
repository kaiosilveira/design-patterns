using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;

namespace LandscapeDesign.DomainTests;

public class UnitTest1
{
  [Fact]
  public void TestConvertsGlyphToUnsharedIfCustomPropertiesAreAdded()
  {
    string[][] expected = {
      new string[] { "🌳", "🟫", "🌳", "🟫", "🌳" },
      new string[] { "🌳", "⬜", "⬜", "⬜", "🟫" },
      new string[] { "🌳", "⬜", "🏠", "⬜", "🌳" },
      new string[] { "🌳", "⬜", "⬜", "⬜", "🟫" },
      new string[] { "🌳", "🟫", "🌳", "🟫", "🌳" },
    };

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