using Xunit;
using AbstractFactoryPattern.Factories;
using AbstractFactoryPattern.Enumerators;
using AbstractFactoryPattern.MazeItems.Enchanted;

namespace AbstractFactoryPattern.Tests.Factories;

public class EnchantedMazeFactoryTest
{
  [Fact]
  public void TestCreateEnchantedWall()
  {
    var wall = new EnchantedMazeFactory().MakeWall(Orientation.HORIZONTAL);
    Assert.IsType<EnchantedWall>(wall);
  }

  [Fact]
  public void TestCreateEnchantedDoor()
  {
    var door = new EnchantedMazeFactory().MakeDoor();
    Assert.IsType<EnchantedDoor>(door);
  }

  [Fact]
  public void TestCreateEnchantedRoom()
  {
    var room = new EnchantedMazeFactory().MakeRoom();
    Assert.IsType<EnchantedRoom>(room);
  }
}