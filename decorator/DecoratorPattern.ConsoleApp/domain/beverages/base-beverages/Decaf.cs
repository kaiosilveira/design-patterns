using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public class Decaf : Beverage
{
  public Decaf() : base()
  {
    this.Description = "Decaf";
  }

  public override double Cost()
  {
    return PricingTable.DECAF;
  }
}