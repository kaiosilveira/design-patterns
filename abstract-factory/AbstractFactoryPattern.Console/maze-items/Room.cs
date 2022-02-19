using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.Interfaces;

namespace AbstractFactoryPattern.MazeItems
{
  using System;

  public class Room : MapSite, Drawable
  {
    private Dictionary<Side, Wall> _walls;

    public Room() => this._walls = new Dictionary<Side, Wall>();

    public void Draw()
    {
      var upperWall = this._walls.First(wallInfo => wallInfo.Key == Side.NORTH).Value;
      var lowerWall = this._walls.First(wallInfo => wallInfo.Key == Side.SOUTH).Value;
      var rightWall = this._walls.First(wallInfo => wallInfo.Key == Side.EAST).Value;
      var leftWall = this._walls.First(wallInfo => wallInfo.Key == Side.WEST).Value;

      this.DrawWall(upperWall);
      this.DrawLateralWalls(leftWall, rightWall);
      this.DrawWall(lowerWall);
    }

    private void DrawWall(Wall wall)
    {
      if (wall.HasDoor)
      {
        this.WriteToConsole(length: 5, wall.GetIcon());
        Console.Write(wall.GetDoorIcon());
        this.WriteToConsole(length: 5, wall.GetIcon());
        Console.WriteLine();
      }
      else
      {
        this.WriteToConsole(length: 11, fillChar: wall.GetIcon());
        Console.WriteLine();
      }
    }

    private void DrawLateralWalls(Wall leftWall, Wall rightWall)
    {

      for (int i = 0; i < 3; i++)
      {
        Console.Write(leftWall.GetIcon());
        this.WriteToConsole(length: 18, fillChar: ".");
        Console.WriteLine(rightWall.GetIcon());
      }

      if (leftWall.HasDoor)
      {
        Console.Write(leftWall.GetDoorIcon());
        this.WriteToConsole(length: 18, fillChar: ".");
        Console.WriteLine(rightWall.GetIcon());
      }

      if (rightWall.HasDoor)
      {
        Console.Write(rightWall.GetIcon());
        this.WriteToConsole(length: 18, fillChar: ".");
        Console.WriteLine(rightWall.GetDoorIcon());
      }

      for (int i = 0; i < 3; i++)
      {
        Console.Write(leftWall.GetIcon());
        this.WriteToConsole(length: 18, fillChar: ".");
        Console.WriteLine(rightWall.GetIcon());
      }
    }

    private void WriteToConsole(int length, string fillChar)
    {
      for (int i = 0; i < length; i++)
      {
        Console.Write(fillChar);
      }
    }

    public void SetSide(Side side, Wall item) => this._walls.Add(side, item);

    public override void Enter() => throw new System.NotImplementedException();
  }
}