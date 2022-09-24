using BoolExParser.Domain;

public class Program
{
  public static void Main(string[] args)
  {
    var context = new InMemoryLanguageContext();
    var x = new VariableExp('x');
    var y = new VariableExp('y');

    Console.WriteLine($"Expression: (true and x) or (y and not x)");

    Console.Write("x: ");
    var xValue = Convert.ToBoolean(Console.ReadLine());
    context.Assign('x', xValue);

    Console.Write("y: ");
    var yValue = Convert.ToBoolean(Console.ReadLine());
    context.Assign('y', yValue);

    var expression = new OrExp(new AndExp(new Constant(true), x), new AndExp(y, new NotExp(x)));
    var result = expression.Evaluate(context);

    Console.WriteLine($"Evaluates to: {result} (x={xValue}, y={yValue})");
  }
}