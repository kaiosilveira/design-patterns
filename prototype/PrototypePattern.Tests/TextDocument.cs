using Xunit;
using PrototypePattern.Documents;

namespace PrototypePattern.Tests;

public class TextDocumentTest
{
  public readonly TextDocument doc;
  public readonly string contents;

  public TextDocumentTest()
  {
    this.contents = "kaio silveira";
    this.doc = new TextDocument(this.contents);
  }

  [Fact]
  public void TestCopy()
  {
    var copiedText = doc.Copy(0, 4);
    Assert.Equal("kaio", copiedText);
  }

  [Fact]
  public void TestPaste()
  {
    var stringToPaste = "vinicius do amaral ";
    doc.Paste(stringToPaste, position: 5);
    Assert.Equal("kaio vinicius do amaral silveira", doc.GetContents());
  }

  [Fact]
  public void TestGetContents()
  {
    Assert.Equal(this.contents, doc.GetContents());
  }
}