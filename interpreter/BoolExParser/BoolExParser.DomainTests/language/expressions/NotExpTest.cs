using Moq;
using Xunit;
using BoolExParser.Domain;

public class NotExpTest
{
  [Fact]
  public void TestGetName()
  {
    var exp = Mock.Of<BooleanExp>();
    var notExp = new NotExp(exp);
    Assert.Equal("not", notExp.GetName());
  }

  [Fact]
  public void TestForwardsCopyCallsToItsUnderlyingExp()
  {
    var mockedExpWrapper = new Mock<BooleanExp>();
    var exp = mockedExpWrapper.Object;
    var notExp = new NotExp(exp);

    notExp.Copy();

    mockedExpWrapper.Verify(instance => instance.Copy(), Times.Once());
  }

  [Fact]
  public void TestEvaluatesAsTheOppositeOfItsUnderlyingExp()
  {
    var mockedContextWrapper = new Mock<Context>();
    var mockedCtx = mockedContextWrapper.Object;
    var mockedExp = new Mock<BooleanExp>();
    mockedExp.Setup(exp => exp.Evaluate(mockedCtx)).Returns(true);

    var notExp = new NotExp(exp: mockedExp.Object);

    Assert.False(notExp.Evaluate(mockedCtx));
  }

  [Fact]
  public void TestForwardsReplaceCallsToItsUnderlyingExp()
  {
    var variableName = 'x';
    var context = Mock.Of<Context>();
    var newExp = Mock.Of<BooleanExp>();
    var exp = new Mock<BooleanExp>();

    var notExp = new NotExp(exp: exp.Object);
    notExp.Replace(variableName, newExp);

    exp.Verify(instance => instance.Replace(variableName, newExp), Times.Once());
  }
}