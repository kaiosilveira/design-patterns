using Xunit;
using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.MazeItems.Bombed;

namespace AbstractFactoryPattern.Tests.Factories;

public class BombedMazeFactoryTest
{
  [Fact]
  public void TestCreateBombedWall()
  {
    var wall = new BombedMazeFactory().MakeWall(Orientation.HORIZONTAL);
    Assert.IsType<BombedWall>(wall);
  }

  [Fact]
  public void TestCreateBombedDoor()
  {
    var door = new BombedMazeFactory().MakeDoor();
    Assert.IsType<BombedDoor>(door);
  }

  [Fact]
  public void TestCreateBombedRoom()
  {
    var room = new BombedMazeFactory().MakeRoom();
    Assert.IsType<BombedRoom>(room);
  }

  [Fact]
  public void TestCreateBombedMaze()
  {
    var maze = new BombedMazeFactory().MakeMaze();
    Assert.IsType<BombedMaze>(maze);
  }
}