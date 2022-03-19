using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Beverages;

public class Expresso : Beverage
{
  public Expresso(BeverageSize size = BeverageSize.TALL)
    : base(size, basePrice: PricingTable.EXPRESSO)
  {
    this.Description = "Expresso";
  }
}