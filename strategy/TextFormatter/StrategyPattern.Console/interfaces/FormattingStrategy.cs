namespace StrategyPattern.Interfaces;

public interface FormattingStrategy
{
  string Format(string value, string? tag);
}
