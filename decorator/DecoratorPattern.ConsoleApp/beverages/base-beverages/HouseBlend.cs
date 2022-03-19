using StarbuzzCoffee.Pricing;

namespace StarbuzzCoffee.Beverages;

public class HouseBlend : Beverage
{
  public HouseBlend(BeverageSize size = BeverageSize.TALL)
    : base(size, basePrice: PricingTable.HOUSE_BLEND)
  {
    this.Description = "House Blend";
  }
}