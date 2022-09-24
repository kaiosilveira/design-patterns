using Moq;
using Xunit;
using BoolExParser.Domain;

namespace BoolExParser.DomainTests;

public class EvaluationTest
{
  [Fact]
  public void TestEvaluatesComplexExpression()
  {
    // exp: (true and x) or (y and (not x))
    // inputs:
    //   x = false
    //   y = true
    // expected result: true

    var x = new VariableExp('x');
    var y = new VariableExp('y');
    var context = new Mock<Context>();
    var expression = new OrExp(new AndExp(new Constant(true), x), new AndExp(y, new NotExp(x)));

    context.Setup(c => c.Lookup('x')).Returns(false);
    context.Setup(c => c.Lookup('y')).Returns(true);

    Assert.True(expression.Evaluate(context.Object));
  }
}