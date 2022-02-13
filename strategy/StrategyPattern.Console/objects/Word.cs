using StrategyPattern.Interfaces;

namespace StrategyPattern.Objects;
public class Word : Renderable
{
  public string Value { get; }

  public Word(string value)
  {
    this.Value = value;
  }

  public string Render(FormattingStrategy formatter)
  {
    return formatter.Format(this.Value, this.GetTag());
  }

  public void Add(Renderable letter)
  {
    throw new NotImplementedException();
  }

  public string GetTag()
  {
    return "span";
  }
}
