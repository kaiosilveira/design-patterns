using Xunit;
using Moq;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;

public class FlyweightGlyphTest
{
  [Fact]
  public void TestSetup()
  {
    var DEFAULT_GLYPH_HEIGHT = 1;
    var glyph = new FlyweightGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square"
    );

    Assert.Equal("🟫", glyph.GetChar());
    Assert.Equal("Brown Square", glyph.GetName());
    Assert.Equal("U+1F7EB", glyph.GetUnicodeValue());
    Assert.Equal(DEFAULT_GLYPH_HEIGHT, glyph.GetHeight());
  }

  [Fact]
  public void TestDisplay()
  {
    var mockedScreen = new Mock<Screen>();
    var glyph = new FlyweightGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square"
    );

    glyph.Display(x: 0, y: 0, screen: mockedScreen.Object);

    mockedScreen.Verify(instance => instance.Add(0, 0, "🟫"), Times.Once());
  }
}