using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public class HouseBlend : Beverage
{
  public HouseBlend(BeverageSize size = BeverageSize.TALL)
    : base(size, basePrice: PricingTable.HOUSE_BLEND)
  {
    this.Description = "House Blend";
  }
}