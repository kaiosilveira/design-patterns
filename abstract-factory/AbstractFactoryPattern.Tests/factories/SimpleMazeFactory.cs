using Xunit;
using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.MazeItems;

namespace AbstractFactoryPattern.Tests.Factories;

public class SimpleMazeFactoryTest
{
  [Fact]
  public void TestCreateSimpleWall()
  {
    var wall = new SimpleMazeFactory().MakeWall(Orientation.HORIZONTAL);
    Assert.IsType<Wall>(wall);
  }

  [Fact]
  public void TestCreateSimpleDoor()
  {
    var door = new SimpleMazeFactory().MakeDoor();
    Assert.IsType<Door>(door);
  }

  [Fact]
  public void TestCreateSimpleRoom()
  {
    var room = new SimpleMazeFactory().MakeRoom();
    Assert.IsType<Room>(room);
  }
}