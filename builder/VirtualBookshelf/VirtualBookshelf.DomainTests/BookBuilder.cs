using Xunit;
using VirtualBookshelf.Domain.ValueObjects;
using VirtualBookshelf.Domain.Builders;
using VirtualBookshelf.Domain.Entities;

namespace VirtualBookshelf.Domain.Tests;

public class BookBuilderTest
{
  [Fact]
  public void TestBuildsWithTheCorrectFields()
  {
    var author = new Author("Martin Fowler");
    var title = "Refactoring";
    var isbn = "0-13-475759-9";
    var publisher = new Publisher("Addison Wesley");
    var price = new Money(5999, "USD");
    var result = new BookBuilder()
      .From(author)
      .By(publisher)
      .WithTitle(title)
      .WithISBN(isbn)
      .WithPrice(price)
      .Build();

    Assert.Equal(title, result.Title);
    Assert.Equal(isbn, result.ISBN);
    Assert.Equal(author, result.Author);
    Assert.Equal(publisher, result.Publisher);
    Assert.Equal(publisher, result.Publisher);
    Assert.Equal(price.AmountInCents, result.Price.AmountInCents);
  }
}