using StrategyPattern.Formatters;
using StrategyPattern.Objects;

namespace StrategyPattern.Console
{
  using System;

  public class Program
  {
    public static void Main(string[] args)
    {
      var name = new Word("Kaio");
      var whitespace = new Word(" ");
      var surname = new Word("Silveira");

      var paragraph = new Paragraph();
      paragraph.Add(name);
      paragraph.Add(whitespace);
      paragraph.Add(surname);

      Console.WriteLine(paragraph.Render(new PlainTextFormatter()));
      Console.WriteLine(paragraph.Render(new HTMLFormatter()));
    }
  }
}