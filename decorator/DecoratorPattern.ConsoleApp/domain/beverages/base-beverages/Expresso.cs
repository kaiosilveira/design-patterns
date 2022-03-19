using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public class Expresso : Beverage
{
  public Expresso() : base()
  {
    this.Description = "Expresso";
  }

  public override double Cost()
  {
    return PricingTable.EXPRESSO;
  }
}