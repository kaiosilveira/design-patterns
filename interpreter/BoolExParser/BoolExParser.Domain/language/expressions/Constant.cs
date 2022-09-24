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
    return new Constant(value);
  }

  public bool Evaluate(Context context)
  {
    return value;
  }

  public string GetName()
  {
    return value.ToString();
  }

  public BooleanExp Replace(char name, BooleanExp exp)
  {
    return Copy();
  }
}