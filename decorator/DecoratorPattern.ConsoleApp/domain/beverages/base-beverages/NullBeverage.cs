namespace StarbuzzCoffee.Domain.Beverages;

public class NullBeverage : Beverage
{
  public NullBeverage()
  {
    this.Description = "Null Beverage";
  }

  public override double Cost()
  {
    return 0.0;
  }
}