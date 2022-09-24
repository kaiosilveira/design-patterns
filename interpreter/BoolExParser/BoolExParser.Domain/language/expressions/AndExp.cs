namespace BoolExParser.Domain;

public class AndExp : BooleanExp
{
  private BooleanExp operand1;
  private BooleanExp operand2;

  public AndExp(BooleanExp operand1, BooleanExp operand2)
  {
    this.operand1 = operand1;
    this.operand2 = operand2;
  }

  public BooleanExp Copy()
  {
    return new AndExp(operand1.Copy(), operand2.Copy());
  }

  public bool Evaluate(Context context)
  {
    return operand1.Evaluate(context) && operand2.Evaluate(context);
  }

  public string GetName()
  {
    return "and";
  }

  public BooleanExp Replace(char c, BooleanExp exp)
  {
    return new AndExp(operand1.Replace(c, exp), operand2.Replace(c, exp));
  }
}
