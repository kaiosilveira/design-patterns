namespace StarbuzzCoffee.Domain.Beverages;

public abstract class Beverage
{
  protected string Description { get; set; }

  public Beverage()
  {
    this.Description = "Unknown Beverage";
  }

  public abstract double Cost();

  public virtual string GetDescription()
  {
    return this.Description;
  }
}
