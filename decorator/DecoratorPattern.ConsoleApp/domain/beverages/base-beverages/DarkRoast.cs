using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public class DarkRoast : Beverage
{
  public DarkRoast() : base()
  {
    this.Description = "Dark Roast Coffee";
  }

  public override double Cost()
  {
    return PricingTable.DARK_ROAST;
  }
}