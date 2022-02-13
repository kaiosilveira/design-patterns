using Xunit;
using StrategyPattern.Formatters;

namespace StrategyPattern.Tests;

public class HTMLFormatterTest
{
  [Fact]
  public void TestFormatToHTML()
  {
    var value = "text";
    var formatter = new HTMLFormatter();
    Assert.Equal($"<p>{value}</p>", formatter.Format(value, "p"));
  }
}