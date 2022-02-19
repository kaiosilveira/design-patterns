using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.MazeItems;

namespace AbstractFactoryPattern.Game;

public class MazeGame
{
  public Maze CreateMaze(MazeFactory factory)
  {
    var leftWall = factory.MakeWall(Orientation.VERTICAL);
    var rightWall = factory.MakeWall(Orientation.VERTICAL);
    var upperWall = factory.MakeWall(Orientation.HORIZONTAL);
    var lowerWall = factory.MakeWall(Orientation.HORIZONTAL);

    leftWall.AddDoor(factory.MakeDoor());
    rightWall.AddDoor(factory.MakeDoor());
    upperWall.AddDoor(factory.MakeDoor());
    lowerWall.AddDoor(factory.MakeDoor());

    var room = new Room();
    room.SetSide(Side.NORTH, upperWall);
    room.SetSide(Side.SOUTH, lowerWall);
    room.SetSide(Side.WEST, leftWall);
    room.SetSide(Side.EAST, rightWall);

    var maze = factory.MakeMaze();
    maze.AddRoom(room);

    return maze;
  }
}