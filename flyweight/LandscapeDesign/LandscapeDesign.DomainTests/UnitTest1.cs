using Xunit;
using System;
using System.Collections.Generic;

namespace LandscapeDesign.DomainTests;

class LandscapeManager
{
  private Glyph[][] matrix;

  public LandscapeManager(int xSize, int ySize)
  {
    this.matrix = this.SetupMatrix(xSize, ySize);
  }

  public Glyph[][] GetDrawingScheme()
  {
    return this.matrix;
  }

  public void Add(int x, int y, Glyph item)
  {
    this.matrix[x][y] = item;
  }

  public void SetName(int x, int y, string name)
  {
    var baseGlyph = this.matrix[x][y];
    var unsharedGlyph = new UnsharedGlyph(baseGlyph.GetChar(), baseGlyph.GetUnicodeValue(), name, baseGlyph.GetHeight());
    this.matrix[x][y] = unsharedGlyph;
  }

  public void SetHeight(int x, int y, int height)
  {
    var baseGlyph = this.matrix[x][y];
    var unsharedGlyph = new UnsharedGlyph(baseGlyph.GetChar(), baseGlyph.GetUnicodeValue(), baseGlyph.GetName(), height);
    this.matrix[x][y] = unsharedGlyph;
  }

  public Glyph Describe(int x, int y)
  {
    return this.matrix[x][y];
  }

  private Glyph[][] SetupMatrix(int xSize, int ySize)
  {
    var temp = new Glyph[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      temp[i] = new Glyph[ySize];
    }

    return temp;
  }
}

public class Window
{
  private string[][] matrix;

  public Window(int xSize, int ySize)
  {
    this.matrix = this.SetupMatrix(xSize, ySize);
  }

  public string[][] GetDrawingScheme()
  {
    return this.matrix;
  }

  public void Add(int x, int y, string item)
  {
    this.matrix[x][y] = item;
  }

  public void SetScheme(Glyph[][] scheme)
  {
    for (int i = 0; i < scheme.Length; i++)
    {
      var row = scheme[i];
      for (int j = 0; j < row.Length; j++)
      {
        var item = row[j];
        item.Display(x: i, y: j, this);
      }
    }
  }

  private string[][] SetupMatrix(int xSize, int ySize)
  {
    var temp = new string[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      temp[i] = new string[ySize];
    }

    return temp;
  }
}

public class Glyph
{
  private readonly string character;
  private readonly string unicodeValue;
  private string name;


  public Glyph(string character, string unicodeValue, string name)
  {
    this.character = character;
    this.unicodeValue = unicodeValue;
    this.name = name;
  }

  public void Display(int x, int y, Window window)
  {
    window.Add(x, y, this.character);
  }

  public virtual int GetHeight()
  {
    return 1;
  }

  public virtual string GetChar()
  {
    return this.character;
  }

  public virtual string GetUnicodeValue()
  {
    return this.unicodeValue;
  }

  public virtual string GetName()
  {
    return this.name;
  }
}

public class UnsharedGlyph : Glyph
{
  private int height;

  public UnsharedGlyph(string character, string unicodeValue, string description, int height) : base(character, unicodeValue, description)
  {
    this.height = height;
  }

  public override int GetHeight()
  {
    return this.height;
  }
}

public static class GlyphRegistry
{
  public static Dictionary<string, Glyph> GLYPHS = new Dictionary<string, Glyph>()
  {
    { "🟫", new Glyph(character: "🟫", unicodeValue: "U+1F7EB", name: "Brown Square") },
    { "⬜", new Glyph(character: "⬜", unicodeValue: "U+2B1C", name: "White Square") },
    { "🌳", new Glyph(character: "🌳", unicodeValue: "U+1F333", name: "Tree") },
    { "🏠", new Glyph(character: "🏠", unicodeValue: "U+1F3E0", name: "House") },
  };
}

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

    landscapeManager.SetHeight(x: 4, y: 1, height: 3);
    landscapeManager.SetName(x: 4, y: 1, name: "My special tree");

    var updatedItem = landscapeManager.Describe(x: 4, y: 1);

    Assert.IsType<UnsharedGlyph>(updatedItem);
    Assert.Equal(3, updatedItem.GetHeight());
    Assert.Equal("My special tree", updatedItem.GetName());
  }
}