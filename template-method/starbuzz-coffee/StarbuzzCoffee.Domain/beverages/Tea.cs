namespace StarbuzzCoffee.Domain.Beverages;

public class Tea : CaffeineBeverage
{
  public bool WithCondiments { get; private set; }

  public Tea(bool withCondiments = true)
  {
    this.WithCondiments = withCondiments;
  }

  protected override void Brew()
  {
    this.BrewState = new BrewState(brewed: true, brewedWith: "Tea Bag");
  }

  protected override void AddCondiments()
  {
    this.Condiments = new List<string> { "Lemon" };
  }

  protected override bool CustomerWantsCondiments()
  {
    return this.WithCondiments;
  }
}
