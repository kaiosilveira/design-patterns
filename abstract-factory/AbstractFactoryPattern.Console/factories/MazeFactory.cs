using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.MazeItems;

namespace AbstractFactoryPattern.Factories;

public abstract class MazeFactory
{
  public abstract Room MakeRoom();

  public abstract Wall MakeWall(Orientation orientation);

  public abstract Door MakeDoor();

  public abstract Maze MakeMaze();
}
