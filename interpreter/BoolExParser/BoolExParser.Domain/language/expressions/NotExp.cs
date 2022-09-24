using BoolExParser.Domain.Language.Contexts;

namespace BoolExParser.Domain.Language.Expressions;

public class NotExp : BooleanExp
{
  private BooleanExp exp;

  public NotExp(BooleanExp exp)
  {
    this.exp = exp;
  }

  public BooleanExp Copy()
  {
    return new NotExp(exp.Copy());
  }

  public bool Evaluate(Context context)
  {
    return !exp.Evaluate(context);
  }

  public string GetName()
  {
    return "not";
  }

  public BooleanExp Replace(char name, BooleanExp newExp)
  {
    return new NotExp(exp.Replace(name, newExp));
  }
}