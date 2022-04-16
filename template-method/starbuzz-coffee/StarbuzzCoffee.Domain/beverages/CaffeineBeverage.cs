using StarbuzzCoffee.Domain.Ingredients;
using StarbuzzCoffee.Domain.Primitives;

namespace StarbuzzCoffee.Domain.Beverages;

public abstract class CaffeineBeverage
{
  public Water WaterState { get; protected set; }
  public BrewState BrewState { get; protected set; }
  public Cup CupState { get; protected set; }
  public IList<string> Condiments { get; protected set; }

  public CaffeineBeverage()
  {
    this.Condiments = new List<string>();
    this.WaterState = new Water(boiled: false);
    this.BrewState = new BrewState(brewed: false, brewedWith: string.Empty);
    this.CupState = new Cup(capacity: 0);
  }

  public void Prepare()
  {
    BoilWater();
    Brew();
    PourInCup();
    if (CustomerWantsCondiments())
    {
      AddCondiments();
    }
  }

  protected abstract void Brew();

  protected abstract void AddCondiments();

  protected void BoilWater()
  {
    this.WaterState = new Water(boiled: true);
  }

  protected void PourInCup()
  {
    this.CupState = new Cup(capacity: 95);
  }

  protected virtual bool CustomerWantsCondiments()
  {
    return true;
  }
}
