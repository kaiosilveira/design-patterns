using Xunit;
using Moq;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Visitors;

class TestMenu : Menu
{
  public TestMenu() : base(name: "Test Menu", description: "A menu for tests") { }
}

public class MenuTest
{
  [Fact]
  public void TestInitialization()
  {
    var menu = new TestMenu();
    Assert.Equal("Test Menu", menu.Name);
    Assert.Equal("A menu for tests", menu.Description);
    Assert.Equal(0, menu.Price);
    Assert.False(menu.IsVegetarian);
  }

  [Fact]
  public void TestAddItem()
  {
    var menu = new TestMenu();
    var item = new MenuItem(
      name: "Test Item", description: "A test item", isVegetarian: false, price: 0
    );

    menu.Add(item);

    Assert.Equal(1, menu.GetNumberOfItems());
  }

  [Fact]
  public void TestRemove()
  {
    var menu = new TestMenu();
    var item = new MenuItem(
      name: "Test Item", description: "A test item", isVegetarian: false, price: 0
    );

    menu.Add(item);
    Assert.Equal(1, menu.GetNumberOfItems());

    menu.Remove(item);
    Assert.Equal(0, menu.GetNumberOfItems());
  }

  [Fact]
  public void TestGetChild()
  {
    var menu = new TestMenu();
    var item = new MenuItem(
      name: "Test Item", description: "A test item", isVegetarian: false, price: 0
    );

    menu.Add(item);

    Assert.Equal(item.Name, menu.GetChild(0).Name);
  }

  [Fact]
  public void TestAcceptsVisitor()
  {
    var visitor = new Mock<Visitor>();
    var menu = new TestMenu();

    menu.Accept(visitor: visitor.Object);

    visitor.Verify(v => v.VisitMenu(menu), Times.Once());
  }
}