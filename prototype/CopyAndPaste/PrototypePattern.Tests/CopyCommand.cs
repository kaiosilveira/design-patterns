using Xunit;
using PrototypePattern.Documents;
using PrototypePattern.Commands;

namespace PrototypePattern.Tests;

public class CopyCommandTest
{
  [Fact]
  public void TestClone()
  {
    var doc = new TextDocument("Hello World!");
    var original = new CopyCommand(doc, 0, doc.GetContents().Length);
    var clone = original.Clone();

    Assert.NotStrictEqual<CopyCommand>(original, clone);
  }

  [Fact]
  public void TestExecute()
  {
    var doc = new TextDocument("Hello World!");
    var cmd = new CopyCommand(doc, 0, doc.GetContents().Length);

    cmd.Execute();

    Assert.Equal("Hello World!", cmd.Buffer);
  }
}