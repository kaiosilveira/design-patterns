using Moq;
using Xunit;
using BoolExParser.Domain.Language.Contexts;
using BoolExParser.Domain.Language.Expressions;

public class ConstantTest
{
  [Fact]
  public void TestCopiesItself()
  {
    var exp = new Constant(true);
    Assert.NotEqual(new Constant(true), exp.Copy());
  }

  [Fact]
  public void TestEvaluatesToTrueIfGivenValueIsTrue()
  {
    var context = Mock.Of<Context>();
    var exp = new Constant(true);
    Assert.True(exp.Evaluate(context));
  }

  [Fact]
  public void TestEvaluatesToFalseIfGivenValueIsFalse()
  {
    var context = Mock.Of<Context>();
    var exp = new Constant(false);
    Assert.False(exp.Evaluate(context));
  }

  [Fact]
  public void TestReplacesItself()
  {
    var exp = new Constant(true);
    var anotherExp = new VariableExp(name: 'x');
    Assert.NotEqual(new Constant(true), exp.Replace(name: 'x', anotherExp));
  }
}