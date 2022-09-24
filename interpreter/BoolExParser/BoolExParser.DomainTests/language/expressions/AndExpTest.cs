using Moq;
using Xunit;
using BoolExParser.Domain.Language.Contexts;
using BoolExParser.Domain.Language.Expressions;

public class AndExpTest
{
  [Fact]
  public void TestGetName()
  {
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();

    var andExp = new AndExp(operand1, operand2);

    Assert.Equal("and", andExp.GetName());
  }

  [Fact]
  public void TestForwardsCopyingToItsOperands()
  {
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();

    var andExp = new AndExp(operand1, operand2);
    andExp.Copy();

    Mock.Get(operand1).Verify(o => o.Copy(), Times.Once());
    Mock.Get(operand2).Verify(o => o.Copy(), Times.Once());
  }

  [Fact]
  public void TestForwardsReplaceCallsToItsOperands()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    var newExp = Mock.Of<BooleanExp>();
    var variableName = 'x';

    var andExp = new AndExp(operand1, operand2);
    andExp.Replace(variableName, newExp);

    Mock.Get(operand1).Verify(o => o.Replace(variableName, newExp), Times.Once());
    Mock.Get(operand2).Verify(o => o.Replace(variableName, newExp), Times.Once());
  }

  [Fact]
  public void TestEvaluatesToTrueIfBothOperandsAreTrue()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    Mock.Get(operand1).Setup(i => i.Evaluate(context)).Returns(true);
    Mock.Get(operand2).Setup(i => i.Evaluate(context)).Returns(true);

    var andExp = new AndExp(operand1, operand2);
    Assert.True(andExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Once());
  }

  [Fact]
  public void TestEvaluatesToFalseAndSkipsSecondOperandEvaluationIfFirstOperandIsFalse()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    Mock.Get(operand1).Setup(i => i.Evaluate(context)).Returns(false);
    Mock.Get(operand2).Setup(i => i.Evaluate(context)).Returns(true);

    var andExp = new AndExp(operand1, operand2);
    Assert.False(andExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Never());
  }

  [Fact]
  public void TestEvaluatesToFalseIfFirstOperandIsTrueAndSecondOperandIsFalse()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    Mock.Get(operand1).Setup(i => i.Evaluate(context)).Returns(true);
    Mock.Get(operand2).Setup(i => i.Evaluate(context)).Returns(false);

    var andExp = new AndExp(operand1, operand2);
    Assert.False(andExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Once());
  }

  [Fact]
  public void TestEvaluatesToFalseIfBothOperandsAreFalse()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    Mock.Get(operand1).Setup(i => i.Evaluate(context)).Returns(false);
    Mock.Get(operand2).Setup(i => i.Evaluate(context)).Returns(false);

    var andExp = new AndExp(operand1, operand2);
    Assert.False(andExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Never());
  }
}