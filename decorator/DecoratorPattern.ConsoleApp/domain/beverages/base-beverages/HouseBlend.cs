namespace StarbuzzCoffee.Domain.Beverages;

public class HouseBlend : Beverage
{
  public HouseBlend() : base()
  {
    this.Description = "House Blend";
  }

  public override double Cost()
  {
    return .89;
  }
}