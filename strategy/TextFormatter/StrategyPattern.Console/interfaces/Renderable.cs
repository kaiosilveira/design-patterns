namespace StrategyPattern.Interfaces;

public interface Renderable
{
  string Render(FormattingStrategy formatter);
  string GetTag();
  void Add(Renderable renderable);
}