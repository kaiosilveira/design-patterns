using Xunit;
using System;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;
using LandscapeDesign.Domain.Managers;

namespace LandscapeDesign.DomainTests;

public class UnitTest1
{
  [Fact]
  public void Test1()
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
    landscapeManager.Add(0, 1, GlyphRegistry.GLYPHS["🟫"]);
    landscapeManager.Add(0, 2, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.Add(0, 3, GlyphRegistry.GLYPHS["🟫"]);
    landscapeManager.Add(0, 4, GlyphRegistry.GLYPHS["🌳"]);

    landscapeManager.Add(1, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.Add(1, 1, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(1, 2, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(1, 3, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(1, 4, GlyphRegistry.GLYPHS["🟫"]);

    landscapeManager.Add(2, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.Add(2, 1, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(2, 2, GlyphRegistry.GLYPHS["🏠"]);
    landscapeManager.Add(2, 3, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(2, 4, GlyphRegistry.GLYPHS["🌳"]);

    landscapeManager.Add(3, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.Add(3, 1, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(3, 2, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(3, 3, GlyphRegistry.GLYPHS["⬜"]);
    landscapeManager.Add(3, 4, GlyphRegistry.GLYPHS["🟫"]);

    landscapeManager.Add(4, 0, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.Add(4, 1, GlyphRegistry.GLYPHS["🟫"]);
    landscapeManager.Add(4, 2, GlyphRegistry.GLYPHS["🌳"]);
    landscapeManager.Add(4, 3, GlyphRegistry.GLYPHS["🟫"]);
    landscapeManager.Add(4, 4, GlyphRegistry.GLYPHS["🌳"]);

    var scheme = landscapeManager.GetDrawingScheme();
    var window = new Window(xSize: 5, ySize: 5);
    window.SetScheme(scheme);
    var result = window.GetDrawingScheme();

    for (int i = 0; i < result.Length; i++)
    {
      var row = result[i];
      for (int j = 0; j < row.Length; j++)
      {
        Console.Write(row[j]);
      }
      Console.Write("\n");
    }

    Assert.Equal(expected, result);
  }

  [Fact]
  public void Test2()
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