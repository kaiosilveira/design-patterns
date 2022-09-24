namespace BoolExParser.Domain;

public class Constant : BooleanExp
{
  private bool value;
  public Constant(bool value)
  {
    this.value = value;
  }

  public BooleanExp Copy()
  {
    return new Constant(this.value);
  }

  public bool Evaluate(Context context)
  {
    return this.value;
  }

  public BooleanExp Replace(char c, BooleanExp exp)
  {
    throw new NotImplementedException();
  }
}