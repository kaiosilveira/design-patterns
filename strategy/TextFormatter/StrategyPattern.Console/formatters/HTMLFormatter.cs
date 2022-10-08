namespace StrategyPattern.Formatters;

public class HTMLFormatter : Formatter
{
  public override string Format(string value, string? tag)
  {
    return $"<{tag}>{value}</{tag}>";
  }
}