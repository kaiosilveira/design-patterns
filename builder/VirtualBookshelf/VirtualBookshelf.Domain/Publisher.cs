namespace VirtualBookshelf.Domain.Entities;

public class Publisher
{
  public string Name { get; }

  public Publisher(string name)
  {
    this.Name = name;
  }
}
