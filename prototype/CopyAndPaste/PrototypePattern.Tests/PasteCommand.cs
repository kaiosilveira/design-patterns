using Xunit;
using PrototypePattern.Documents;
using PrototypePattern.Commands;

namespace PrototypePattern.Tests;

public class PasteCommandTest
{
  [Fact]
  public void TestClone()
  {
    var original = new PasteCommand(new TextDocument("Hello world!"), "I'm here!", 0);

    var clone = original.Clone();

    Assert.NotStrictEqual<PasteCommand>(original, clone);
  }

  [Fact]
  public void TestExecute()
  {
    var doc = new TextDocument("Hello World!");
    var cmd = new PasteCommand(doc, " I'm here!", doc.GetContents().Length);

    cmd.Execute();

    Assert.Equal("Hello World! I'm here!", doc.GetContents());
  }
}