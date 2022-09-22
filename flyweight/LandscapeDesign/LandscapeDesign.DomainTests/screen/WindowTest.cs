using Xunit;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Managers;
using LandscapeDesign.Domain.Screens;

public class ScreenTest
{
  public readonly ScreenRect DEFAULT_5x5_SCREEN_RECT = new ScreenRect(xLength: 5, yLength: 5);

  [Fact]
  public void TestPaint()
  {
    string[][] expected = {
      new string[] { "🌳", "🟫", "🌳", "🟫", "🌳" },
      new string[] { "🌳", "⬜", "⬜", "⬜", "🟫" },
      new string[] { "🌳", "⬜", "🏠", "⬜", "🌳" },
      new string[] { "🌳", "⬜", "⬜", "⬜", "🟫" },
      new string[] { "🌳", "🟫", "🌳", "🟫", "🌳" },
    };

    var landscapeManager = new LandscapeManager(DEFAULT_5x5_SCREEN_RECT);

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

    var scheme = landscapeManager.GetGlyphMap();
    var screen = new ConcreteScreen(xSize: 5, ySize: 5);
    var result = screen.GetSymbolMap();

    screen.SetupDisplay(scheme);

    Assert.Equal(expected, result);
  }

  [Fact]
  public void TestPaintsBrownSquaresIfLandscapeIsEmpty()
  {
    string[][] expected = {
      new string[] { "🟫", "🟫", "🟫", "🟫", "🟫" },
      new string[] { "🟫", "🟫", "🟫", "🟫", "🟫" },
      new string[] { "🟫", "🟫", "🟫", "🟫", "🟫" },
      new string[] { "🟫", "🟫", "🟫", "🟫", "🟫" },
      new string[] { "🟫", "🟫", "🟫", "🟫", "🟫" },
    };

    var manager = new LandscapeManager(DEFAULT_5x5_SCREEN_RECT);
    var screen = new ConcreteScreen(xSize: 5, ySize: 5);
    screen.SetupDisplay(manager.GetGlyphMap());

    Assert.Equal(expected, screen.GetSymbolMap());
  }
}