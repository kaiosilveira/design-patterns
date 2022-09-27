using ObjectvilleFood.Domain.Visitors;

namespace ObjectvilleFood.Domain.MenuDefinition;

public class Menu : MenuComponent
{
  protected List<MenuComponent> menuComponents;

  public Menu(string name, string description)
    : base(name, description, isVegetarian: false, price: 0)
  {
    this.menuComponents = new List<MenuComponent>();
  }

  public int GetNumberOfItems()
  {
    return this.menuComponents.Count;
  }

  public override MenuComponent GetChild(int i)
  {
    return this.menuComponents.ElementAt(i);
  }

  public override void Add(MenuComponent component)
  {
    this.menuComponents.Add(component);
  }

  public override void Remove(MenuComponent component)
  {
    this.menuComponents.Remove(component);
  }

  public override void Print()
  {
    Console.WriteLine(this.Name.ToUpper());
    Console.WriteLine(this.Description);
    Console.WriteLine("---------------------------------");

    this.menuComponents.ForEach(component => component.Print());
  }

  public void Accept(Visitor visitor)
  {
    visitor.VisitMenu(this);
  }
}