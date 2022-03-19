namespace StarbuzzCoffee.Domain.Beverages;

public class DarkRoast : Beverage
{
  public DarkRoast() : base()
  {
    this.Description = "Dark Roast Coffee";
  }

  public override double Cost()
  {
    return .99;
  }
}