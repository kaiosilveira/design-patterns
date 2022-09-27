using ObjectvilleFood.Domain.Exceptions;

namespace ObjectvilleFood.Domain.MenuDefinition;

public abstract class MenuComponent
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public int Price { get; private set; }
  public bool IsVegetarian { get; private set; }

  public MenuComponent(string name, string description, bool isVegetarian, int price)
  {
    this.Name = name;
    this.Description = description;
    this.Price = price;
    this.IsVegetarian = isVegetarian;
  }

  public virtual void Add(MenuComponent component)
  {
    throw new UnsupportedOperationException();
  }

  public virtual void Remove(MenuComponent component)
  {
    throw new UnsupportedOperationException();
  }

  public virtual MenuComponent GetChild(int i)
  {
    throw new UnsupportedOperationException();
  }

  public virtual void Print()
  {
    throw new UnsupportedOperationException();
  }
}