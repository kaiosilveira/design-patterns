namespace StarbuzzCoffee.Beverages;

public class NullBeverage : Beverage
{
  public NullBeverage(BeverageSize size = BeverageSize.TALL) : base(size, 0.0)
  {
    this.Description = "Null Beverage";
  }
}