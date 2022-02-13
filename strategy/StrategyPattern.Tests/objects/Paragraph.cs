using Xunit;
using StrategyPattern.Formatters;
using StrategyPattern.Objects;

namespace StrategyPattern.Tests;

public class ParagraphTest
{
  Paragraph paragraph;
  string name, surname, whitespace;
  public ParagraphTest()
  {
    name = "Kaio";
    whitespace = " ";
    surname = "Silveira";

    paragraph = new Paragraph();
    paragraph.Add(new Word(name));
    paragraph.Add(new Word(whitespace));
    paragraph.Add(new Word(surname));
  }

  [Fact]
  public void TestRendersAsPlainTextIfPlainTextFormatterIsGivenAsFormattingStrategy()
  {
    Assert.Equal($"{name}{whitespace}{surname}", paragraph.Render(new PlainTextFormatter()));
  }

  [Fact]
  public void TestRendersAsASpanIfHTMLFormatterIsGivenAsFormattingStrategy()
  {
    Assert.Equal(
      $"<p><span>{name}</span><span> </span><span>Silveira</span></p>",
      paragraph.Render(new HTMLFormatter())
    );
  }
}