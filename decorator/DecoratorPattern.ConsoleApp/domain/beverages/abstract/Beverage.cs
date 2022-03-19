using StarbuzzCoffee.Domain.Pricing;

namespace StarbuzzCoffee.Domain.Beverages;

public abstract class Beverage
{
  protected double BasePrice { get; }
  protected string Description { get; set; }
  protected BeverageSize Size { get; set; }

  public Beverage(BeverageSize size = BeverageSize.TALL, double basePrice = 0.0)
  {
    this.BasePrice = basePrice;
    this.Description = "Unknown Beverage";
    this.Size = size;
  }

  public virtual double Cost()
  {
    switch (this.Size)
    {
      case BeverageSize.VENTI:
        return this.BasePrice + .4;
      case BeverageSize.GRANDE:
        return this.BasePrice + .2;
      case BeverageSize.TALL:
      default:
        return this.BasePrice;
    }
  }

  public virtual string GetDescription()
  {
    return this.Description;
  }
}
