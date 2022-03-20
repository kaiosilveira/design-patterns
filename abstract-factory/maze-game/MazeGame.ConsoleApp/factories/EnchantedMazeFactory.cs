using MazeGame.Enumerators;
using MazeGame.MazeItems;
using MazeGame.MazeItems.Enchanted;

namespace MazeGame.Factories;

public class EnchantedMazeFactory : MazeFactory
{
  public override Door MakeDoor()
  {
    return new EnchantedDoor();
  }

  public override Maze MakeMaze()
  {
    return new EnchantedMaze();
  }

  public override Room MakeRoom()
  {
    return new EnchantedRoom();
  }

  public override Wall MakeWall(Orientation orientation)
  {
    return new EnchantedWall(orientation);
  }
}