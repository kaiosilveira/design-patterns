using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Beverages;

public class DarkRoast : Beverage
{
  public DarkRoast(BeverageSize size = BeverageSize.TALL)
    : base(size, basePrice: PricingTable.DARK_ROAST)
  {
    this.Description = "Dark Roast Coffee";
  }
}