using Xunit;
using BoolExParser.Domain.Language.Contexts;

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