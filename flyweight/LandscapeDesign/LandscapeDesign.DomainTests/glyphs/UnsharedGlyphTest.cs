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
      name: "Brown Square"
    );

    Assert.Equal("🟫", glyph.GetChar());
    Assert.Equal("Brown Square", glyph.GetName());
    Assert.Equal("U+1F7EB", glyph.GetUnicodeValue());
  }

  [Fact]
  public void TestDisplay()
  {
    var mockedScreen = new Mock<Screen>();
    var glyph = new UnsharedGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square"
    );

    glyph.Display(x: 0, y: 0, screen: mockedScreen.Object);

    mockedScreen.Verify(instance => instance.Add(0, 0, "🟫"), Times.Once());
  }

  [Fact]
  public void TestCreatesNewInstanceBasedOnExistingGlyph()
  {
    var newName = "My custom name";
    var mockedScreen = new Mock<Screen>();
    var existingGlyph = new FlyweightGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square"
    );

    var newGlyph = UnsharedGlyph.FromExisting(existingGlyph, name: newName);

    Assert.Equal(newName, newGlyph.GetName());
    Assert.Equal(existingGlyph.GetChar(), newGlyph.GetChar());
    Assert.Equal(existingGlyph.GetUnicodeValue(), newGlyph.GetUnicodeValue());
  }
}