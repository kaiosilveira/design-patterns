namespace VirtualBookshelf.Domain.ValueObjects;

public class Author
{
  public string Name { get; }

  public Author(string name)
  {
    this.Name = name;
  }
}
