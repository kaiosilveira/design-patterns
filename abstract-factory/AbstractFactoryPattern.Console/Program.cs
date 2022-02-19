using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.Game;

namespace AbstractFactoryPattern.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var enchantedMaze = new MazeGame().CreateMaze(new EnchantedMazeFactory());
    Console.WriteLine("Using enchanted factory:");
    enchantedMaze.Draw();

    var bombedMaze = new MazeGame().CreateMaze(new BombedMazeFactory());
    Console.WriteLine("Using bombed factory:");
    bombedMaze.Draw();

    var simpleMaze = new MazeGame().CreateMaze(new SimpleMazeFactory());
    Console.WriteLine("Using simple factory:");
    simpleMaze.Draw();
  }
}
