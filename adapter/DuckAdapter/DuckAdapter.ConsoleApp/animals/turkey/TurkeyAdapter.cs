namespace DuckAdapter.Animals.Adapters;

public class TurkeyAdapter : Duck
{
  Turkey turkey;

  public TurkeyAdapter(Turkey turkey)
  {
    this.turkey = turkey;
  }

  public void Fly()
  {
    for (int i = 0; i < 5; i++)
    {
      this.turkey.Fly();
    }
  }

  public void Quack()
  {
    this.turkey.Gobble();
  }
}