using MazeGame;
using MazeGame.Factories;

namespace MazeGame.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var enchantedMaze = new Game().CreateMaze(new EnchantedMazeFactory());
    Console.WriteLine("Using enchanted factory:");
    enchantedMaze.Draw();

    var bombedMaze = new Game().CreateMaze(new BombedMazeFactory());
    Console.WriteLine("Using bombed factory:");
    bombedMaze.Draw();

    var simpleMaze = new Game().CreateMaze(new SimpleMazeFactory());
    Console.WriteLine("Using simple factory:");
    simpleMaze.Draw();
  }
}
