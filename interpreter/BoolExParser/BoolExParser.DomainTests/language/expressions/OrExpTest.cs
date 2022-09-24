using Moq;
using Xunit;
using BoolExParser.Domain;

public class OrExpTest
{
  [Fact]
  public void TestGetName()
  {
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();

    var orExp = new OrExp(operand1, operand2);

    Assert.Equal("or", orExp.GetName());
  }

  [Fact]
  public void TestForwardsCopyingToItsOperands()
  {
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();

    var orExp = new OrExp(operand1, operand2);
    orExp.Copy();

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

    var orExp = new OrExp(operand1, operand2);
    orExp.Replace(variableName, newExp);

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

    var orExp = new OrExp(operand1, operand2);
    Assert.True(orExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Never());
  }

  [Fact]
  public void TestEvaluatesToTrueAndSkipsEvaluationOfTheSecondOperandIfFirstOperandIsTrue()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    Mock.Get(operand1).Setup(i => i.Evaluate(context)).Returns(true);
    Mock.Get(operand2).Setup(i => i.Evaluate(context)).Returns(false);

    var orExp = new OrExp(operand1, operand2);
    Assert.True(orExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Never());
  }

  [Fact]
  public void TestEvaluatesToTrueIfFirstOperandIsFalseAndSecondOperandIsTrue()
  {
    var context = Mock.Of<Context>();
    var operand1 = Mock.Of<BooleanExp>();
    var operand2 = Mock.Of<BooleanExp>();
    Mock.Get(operand1).Setup(i => i.Evaluate(context)).Returns(false);
    Mock.Get(operand2).Setup(i => i.Evaluate(context)).Returns(true);

    var orExp = new OrExp(operand1, operand2);
    Assert.True(orExp.Evaluate(context));

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

    var orExp = new OrExp(operand1, operand2);
    Assert.False(orExp.Evaluate(context));

    Mock.Get(operand1).Verify(o => o.Evaluate(context), Times.Once());
    Mock.Get(operand2).Verify(o => o.Evaluate(context), Times.Once());
  }
}