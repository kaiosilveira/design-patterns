using StrategyPattern.Interfaces;

namespace StrategyPattern.Objects;
public class Paragraph : Renderable
{
  public List<Renderable> Words { get; }
  public Paragraph()
  {
    this.Words = new List<Renderable>();
  }

  public string Render(FormattingStrategy formatter)
  {
    var result = "";

    this.Words.ForEach(word =>
    {
      result += word.Render(formatter);
    });

    return formatter.Format(result, this.GetTag());
  }

  public void Add(Renderable word)
  {
    this.Words.Add(word);
  }

  public string GetTag()
  {
    return "p";
  }
}
