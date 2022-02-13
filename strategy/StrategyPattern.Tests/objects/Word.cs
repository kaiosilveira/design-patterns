using Xunit;
using StrategyPattern.Formatters;
using StrategyPattern.Objects;

namespace StrategyPattern.Tests;

public class WordTest
{
  string value;
  Word word;
  public WordTest()
  {
    value = "kaio silveira";
    word = new Word(value);
  }

  [Fact]
  public void TestRendersAsPlainTextIfPlainTextFormatterIsGivenAsFormattingStrategy()
  {
    Assert.Equal(value, word.Render(new PlainTextFormatter()));
  }

  [Fact]
  public void TestRendersAsASpanIfHTMLFormatterIsGivenAsFormattingStrategy()
  {
    Assert.Equal($"<span>{value}</span>", word.Render(new HTMLFormatter()));
  }
}