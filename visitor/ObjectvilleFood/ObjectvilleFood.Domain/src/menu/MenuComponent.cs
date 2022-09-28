using ObjectvilleFood.Domain.Exceptions;
using ObjectvilleFood.Domain.Visitors;

namespace ObjectvilleFood.Domain.MenuDefinition;

public abstract class MenuComponent
{
  public string Name { get; private set; }
  public string Description { get; private set; }
  public int Price { get; private set; }
  public bool IsVegetarian { get; private set; }
  public double ProteinInGrams { get; private set; }
  public double CarbohydratesInGrams { get; private set; }
  public double FatInGrams { get; private set; }
  public string HealthScore { get; private set; }

  public MenuComponent(
    string name, string description, bool isVegetarian, int price,
    double proteinInGrams, double carbohydratesInGrams, double fatInGrams,
    string healthScore = "?"
  )
  {
    this.Name = name;
    this.Description = description;
    this.Price = price;
    this.IsVegetarian = isVegetarian;
    this.HealthScore = healthScore;
    this.ProteinInGrams = proteinInGrams;
    this.CarbohydratesInGrams = carbohydratesInGrams;
    this.FatInGrams = fatInGrams;
  }

  public virtual void Accept(Visitor v) => throw new UnsupportedOperationException();

  public virtual void Add(MenuComponent component) => throw new UnsupportedOperationException();

  public virtual void Remove(MenuComponent component) => throw new UnsupportedOperationException();

  public virtual void Print() => throw new UnsupportedOperationException();

  public virtual MenuComponent GetChild(int i) => throw new UnsupportedOperationException();
}