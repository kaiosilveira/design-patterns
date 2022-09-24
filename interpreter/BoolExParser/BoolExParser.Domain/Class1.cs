namespace BoolExParser.Domain;

public interface BooleanExp
{
  public bool Evaluate(Context context);
  public BooleanExp Replace(char name, BooleanExp exp);
  public BooleanExp Copy();
}

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

  public BooleanExp Replace(char name, BooleanExp exp)
  {
    return this.name == name ? exp.Copy() : new VariableExp(this.name);
  }
}

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

  public BooleanExp Replace(char c, BooleanExp exp)
  {
    return new AndExp(operand1.Replace(c, exp), operand2.Replace(c, exp));
  }
}

public class OrExp : BooleanExp
{
  private BooleanExp operand1;
  private BooleanExp operand2;

  public OrExp(BooleanExp operand1, BooleanExp operand2)
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
    return operand1.Evaluate(context) || operand2.Evaluate(context);
  }

  public BooleanExp Replace(char c, BooleanExp exp)
  {
    return new OrExp(operand1.Replace(c, exp), operand2.Replace(c, exp));
  }
}

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

public interface Context
{
  public bool Lookup(char variableName);
  public void Assign(char exp, bool value);
}

public class TestingContext : Context
{
  private Dictionary<char, bool> variableDictionary;

  public TestingContext()
  {
    this.variableDictionary = new Dictionary<char, bool>();
  }

  public void Assign(char exp, bool value)
  {
    this.variableDictionary.Add(exp, value);
  }

  public bool Lookup(char variableName)
  {
    return this.variableDictionary.GetValueOrDefault<char, bool>(variableName, false);
  }
}