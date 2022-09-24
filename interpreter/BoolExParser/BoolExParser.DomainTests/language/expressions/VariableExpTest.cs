using Xunit;
using Moq;
using BoolExParser.Domain.Language.Contexts;
using BoolExParser.Domain.Language.Expressions;

public class VariableExpTest
{
  [Fact]
  public void TestCopiesItself()
  {
    var exp = new VariableExp(name: 'x');
    var copy = exp.Copy();

    Assert.Equal(exp.GetName(), copy.GetName());
  }

  [Fact]
  public void TestReturnsItsName()
  {
    var exp = new VariableExp(name: 'x');
    Assert.Equal("x", exp.GetName());
  }

  [Fact]
  public void TestReplacesItselfItNameMatches()
  {
    var exp = new VariableExp(name: 'x');
    var anotherExp = new VariableExp(name: 'x');
    var replacement = exp.Replace(name: 'x', anotherExp);

    Assert.Equal(exp.GetName(), replacement.GetName());
  }

  [Fact]
  public void TestDoesNotReplaceItselfItNameDoesNotMatch()
  {
    var exp = new VariableExp(name: 'x');
    var anotherExp = new VariableExp(name: 'y');
    var replacement = exp.Replace(name: 'x', anotherExp);

    Assert.NotEqual(exp.GetName(), replacement.GetName());
  }

  [Fact]
  public void TestEvaluatesToTheValueInTheContext()
  {
    var mockedContext = new Mock<Context>();
    mockedContext.Setup(context => context.Lookup('x')).Returns(true);

    var exp = new VariableExp(name: 'x');

    Assert.True(exp.Evaluate(context: mockedContext.Object));
  }
}