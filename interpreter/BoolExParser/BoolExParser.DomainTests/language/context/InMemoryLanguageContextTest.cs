using Xunit;
using BoolExParser.Domain;

public class InMemoryLanguageContextTest
{
  [Fact]
  public void TestAssignAndLookup()
  {
    var ctx = new InMemoryLanguageContext();
    ctx.Assign('x', value: true);
    Assert.True(ctx.Lookup('x'));
  }
}