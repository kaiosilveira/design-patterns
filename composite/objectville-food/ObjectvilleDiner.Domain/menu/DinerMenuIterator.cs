using ObjectvilleFood.Domain.Exceptions;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;

namespace ObjectvilleDiner.Domain.MenuDefinition;

public class DinerMenuIterator : Iterator<MenuItem>
{
  MenuItem[] items;
  int position = 0;

  public DinerMenuIterator(MenuItem[] items)
  {
    this.items = items;
  }

  public bool HasNext()
  {
    if (items.Length == 0 || position >= items.Length || items[position] == null)
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
    if (!this.HasNext())
    {
      throw new IteratorOutOfBoundsException();
    }

    var menuItem = items[position];
    position = position + 1;
    return menuItem;
  }
}