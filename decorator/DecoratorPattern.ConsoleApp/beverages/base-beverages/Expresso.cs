using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public class Expresso : Beverage
{
  public Expresso(BeverageSize size = BeverageSize.TALL)
    : base(size, basePrice: PricingTable.EXPRESSO)
  {
    this.Description = "Expresso";
  }
}