﻿using LandscapeDesign.Domain.Glyphs;

namespace LandscapeDesign.Domain.Screens;

public class ConcreteScreen : Screen
{
  private string[][] matrix;

  public ConcreteScreen(int xSize, int ySize)
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

  public void Paint()
  {
    for (int i = 0; i < this.matrix.Length; i++)
    {
      var row = this.matrix[i];
      for (int j = 0; j < row.Length; j++)
      {
        Console.Write(row[j]);
      }
      Console.Write("\n");
    }
  }

  private string[][] SetupMatrix(int xSize, int ySize)
  {
    var result = new string[xSize][];

    for (int i = 0; i < ySize; i++)
    {
      result[i] = new string[ySize];
    }

    return result;
  }
}
