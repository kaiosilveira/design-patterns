using Xunit;
using Moq;
using LandscapeDesign.Domain.Glyphs;
using LandscapeDesign.Domain.Screens;

public class UnsharedGlyphTest
{
  [Fact]
  public void TestDisplay()
  {
    var mockedWindow = new Mock<Window>();
    var glyph = new UnsharedGlyph(
      character: "🟫",
      unicodeValue: "U+1F7EB",
      name: "Brown Square",
      height: 3
    );

    glyph.Display(x: 0, y: 0, window: mockedWindow.Object);

    mockedWindow.Verify(instance => instance.Add(0, 0, "🟫"), Times.Once());
  }
}