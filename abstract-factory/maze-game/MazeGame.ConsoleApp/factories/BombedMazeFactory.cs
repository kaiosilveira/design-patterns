using MazeGame.Enumerators;
using MazeGame.MazeItems;
using MazeGame.MazeItems.Bombed;

namespace MazeGame.Factories;

public class BombedMazeFactory : MazeFactory
{
  public override Door MakeDoor()
  {
    return new BombedDoor();
  }

  public override Maze MakeMaze()
  {
    return new BombedMaze();
  }

  public override Room MakeRoom()
  {
    return new BombedRoom();
  }

  public override Wall MakeWall(Orientation orientation)
  {
    return new BombedWall(orientation);
  }
}