using Xunit;
using StrategyPattern.Formatters;

namespace StrategyPattern.Tests;

public class PlainTextFormatterTest
{
  [Fact]
  public void TestFormatToPlainText()
  {
    var value = "kaio silveira";
    var formatter = new PlainTextFormatter();
    Assert.Equal(value, formatter.Format(value, ""));
  }
}