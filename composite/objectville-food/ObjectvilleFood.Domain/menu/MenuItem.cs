namespace ObjectvilleFood.Domain.MenuDefinition;

public class MenuItem
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public bool IsVegetarian { get; private set; }
  public int Price { get; private set; }

  public MenuItem(string name, string description, bool isVegetarian, int price)
  {
    this.Name = name;
    this.Description = description;
    this.IsVegetarian = isVegetarian;
    this.Price = price;
  }
}