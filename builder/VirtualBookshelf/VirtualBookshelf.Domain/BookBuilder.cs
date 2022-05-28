
using VirtualBookshelf.Domain.Entities;
using VirtualBookshelf.Domain.ValueObjects;

namespace VirtualBookshelf.Domain.Builders;

public class BookBuilder
{
  private string isbn { get; set; }

  private string title { get; set; }

  private Author author { get; set; }

  private Publisher publisher { get; set; }

  private Money price { get; set; }

  public BookBuilder()
  {
    this.title = "Null Book";
    this.isbn = "00-000-0000-0";
    this.author = new Author("Unknown Author");
    this.publisher = new Publisher("Unknown Publisher");
    this.price = new Money(0, "USD");
  }

  public BookBuilder From(Author author)
  {
    this.author = author;
    return this;
  }

  public BookBuilder By(Publisher publisher)
  {
    this.publisher = publisher;
    return this;
  }

  public BookBuilder WithTitle(string title)
  {
    this.title = title;
    return this;
  }

  public BookBuilder WithISBN(string isbn)
  {
    this.isbn = isbn;
    return this;
  }

  public BookBuilder WithPrice(Money price)
  {
    this.price = price;
    return this;
  }

  public Book Build()
  {
    return new Book(
      this.isbn,
      this.title,
      this.author,
      this.publisher,
      this.price
    );
  }
}
