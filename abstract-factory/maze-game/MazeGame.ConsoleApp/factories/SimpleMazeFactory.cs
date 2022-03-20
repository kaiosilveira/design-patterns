using MazeGame.Enumerators;
using MazeGame.MazeItems;

namespace MazeGame.Factories;

public class SimpleMazeFactory : MazeFactory
{
  public override Door MakeDoor()
  {
    return new Door();
  }

  public override Maze MakeMaze()
  {
    return new Maze();
  }

  public override Room MakeRoom()
  {
    return new Room();
  }

  public override Wall MakeWall(Orientation orientation)
  {
    return new Wall(orientation);
  }
}