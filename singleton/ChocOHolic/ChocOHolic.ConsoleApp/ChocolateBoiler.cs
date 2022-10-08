
namespace ChocoOHolic.Boiler;

public class ChocolateBoiler
{
  protected volatile static ChocolateBoiler? uniqueInstance;
  public bool Empty { get; private set; }
  public bool Boiled { get; private set; }

  protected ChocolateBoiler()
  {
    this.Empty = true;
    this.Boiled = false;
  }

  public static ChocolateBoiler GetInstance()
  {
    if (uniqueInstance == null)
    {
      uniqueInstance = new ChocolateBoiler();
    }

    return uniqueInstance;
  }

  public void Fill()
  {
    if (Empty)
    {
      this.Empty = false;
      this.Boiled = false;
    }
  }

  public void Drain()
  {
    if (!this.Empty && this.Boiled)
    {
      this.Empty = true;
    }
  }

  public void Boil()
  {
    if (!this.Empty && !this.Boiled)
    {
      this.Boiled = true;
    }
  }
}