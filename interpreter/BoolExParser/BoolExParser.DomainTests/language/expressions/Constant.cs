using Xunit;
using BoolExParser.Domain;
using BoolExParser.DomainTests.Language.Contexts;

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
    var context = new TestingContext();
    var exp = new Constant(true);
    Assert.True(exp.Evaluate(context));
  }

  [Fact]
  public void TestEvaluatesToFalseIfGivenValueIsFalse()
  {
    var context = new TestingContext();
    var exp = new Constant(false);
    Assert.False(exp.Evaluate(context));
  }
}