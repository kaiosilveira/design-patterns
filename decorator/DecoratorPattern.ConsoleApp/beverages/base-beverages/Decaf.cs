using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public class Decaf : Beverage
{
  public Decaf(BeverageSize size = BeverageSize.TALL) : base(size, basePrice: PricingTable.DECAF)
  {
    this.Description = "Decaf";
  }
}