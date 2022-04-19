using ObjectvilleFood.Domain.Exceptions;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;

namespace ObjectvilleCafe.Domain;

public class CafeMenuIterator : Iterator<MenuItem>
{
  private Dictionary<string, MenuItem> items;
  private int currentPosition;

  public CafeMenuIterator(Dictionary<string, MenuItem> items)
  {
    this.items = items;
    this.currentPosition = 0;
  }

  public bool HasNext()
  {
    if (this.items.Count == 0 || this.currentPosition >= this.items.Count())
    {
      return false;
    }
    else
    {
      return true;
    }
  }

  public MenuItem Next()
  {
    if (this.items.Count() == 0)
    {
      throw new IteratorOutOfBoundsException();
    }

    var item = this.items.ElementAt(this.currentPosition).Value;
    this.currentPosition++;
    return item;
  }
}