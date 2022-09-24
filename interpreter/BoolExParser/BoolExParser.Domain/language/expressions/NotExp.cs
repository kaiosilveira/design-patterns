namespace BoolExParser.Domain;

public class NotExp : BooleanExp
{
  private BooleanExp exp;

  public NotExp(BooleanExp exp)
  {
    this.exp = exp;
  }

  public BooleanExp Copy()
  {
    return new NotExp(this.exp);
  }

  public bool Evaluate(Context context)
  {
    return !this.exp.Evaluate(context);
  }

  public BooleanExp Replace(char name, BooleanExp exp)
  {
    return new NotExp(exp.Replace(name, exp));
  }
}