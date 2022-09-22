namespace LandscapeDesign.Domain;

public class LandscapeManager
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