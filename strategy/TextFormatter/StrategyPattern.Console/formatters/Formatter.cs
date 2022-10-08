using StrategyPattern.Interfaces;
namespace StrategyPattern.Formatters;

public abstract class Formatter : FormattingStrategy
{
  public virtual string Format(string value, string? tag)
  {
    return value;
  }
}