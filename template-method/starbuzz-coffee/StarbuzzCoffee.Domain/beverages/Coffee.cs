namespace StarbuzzCoffee.Domain.Beverages;

public class Coffee : CaffeineBeverage
{
  public bool WithCondiments { get; private set; }

  public Coffee(bool withCondiments = true)
  {
    this.WithCondiments = withCondiments;
  }

  protected override void Brew()
  {
    this.BrewState = new BrewState(brewed: true, brewedWith: "Coffee Grinds");
  }

  protected override void AddCondiments()
  {
    this.Condiments = new List<string> { "Sugar", "Milk" };
  }

  protected override bool CustomerWantsCondiments()
  {
    return this.WithCondiments;
  }
}