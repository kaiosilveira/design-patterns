using MazeGame.Enumerators;
using MazeGame.MazeItems;

namespace MazeGame.Factories;

public abstract class MazeFactory
{
  public abstract Room MakeRoom();

  public abstract Wall MakeWall(Orientation orientation);

  public abstract Door MakeDoor();

  public abstract Maze MakeMaze();
}
