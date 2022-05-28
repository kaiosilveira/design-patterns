using VirtualBookshelf.Domain.ValueObjects;

namespace VirtualBookshelf.Domain.Entities;

public class Book
{
  public string ISBN { get; }

  public string Title { get; }

  public Author Author { get; }

  public Publisher Publisher { get; }

  public Money Price { get; }

  public Book(string isbn, string title, Author author, Publisher publisher, Money price)
  {
    this.ISBN = isbn;
    this.Title = title;
    this.Author = author;
    this.Publisher = publisher;
    this.Price = price;
  }
}
