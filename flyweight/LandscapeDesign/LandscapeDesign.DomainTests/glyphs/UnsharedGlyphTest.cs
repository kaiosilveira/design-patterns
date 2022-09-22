using Xunit;
using Moq;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;

public class UnsharedGlyphTest
{
  [Fact]
  public void TestSetup()
  {
    var glyph = new UnsharedGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square",
      height: 3
    );

    Assert.Equal("🟫", glyph.GetChar());
    Assert.Equal("Brown Square", glyph.GetName());
    Assert.Equal("U+1F7EB", glyph.GetUnicodeValue());
    Assert.Equal(3, glyph.GetHeight());
  }

  [Fact]
  public void TestDisplay()
  {
    var mockedScreen = new Mock<Screen>();
    var glyph = new UnsharedGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square",
      height: 3
    );

    glyph.Display(x: 0, y: 0, screen: mockedScreen.Object);

    mockedScreen.Verify(instance => instance.Add(0, 0, "🟫"), Times.Once());
  }
}