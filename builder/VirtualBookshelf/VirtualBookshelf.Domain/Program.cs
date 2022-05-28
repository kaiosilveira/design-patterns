using VirtualBookshelf.Domain.Builders;

namespace BuilderPattern.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var book = new BookBuilder().Build();
    Console.WriteLine(book.Title);
  }
}