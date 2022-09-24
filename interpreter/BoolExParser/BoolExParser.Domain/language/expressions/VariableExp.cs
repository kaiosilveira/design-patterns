using BoolExParser.Domain.Language.Contexts;

namespace BoolExParser.Domain.Language.Expressions;

public class VariableExp : BooleanExp
{
  char name;
  public VariableExp(char name)
  {
    this.name = name;
  }

  public BooleanExp Copy()
  {
    return new VariableExp(this.name);
  }

  public bool Evaluate(Context context)
  {
    return context.Lookup(this.name);
  }

  public string GetName()
  {
    return this.name.ToString();
  }

  public BooleanExp Replace(char name, BooleanExp exp)
  {
    return this.name == name ? exp.Copy() : new VariableExp(this.name);
  }
}