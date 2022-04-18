using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Utils;

namespace PancakeHouse.Domain.MenuDefinition;

public class PancakeHouseMenuIterator : Iterator<MenuItem>
{
  private List<MenuItem> menuItems;

  public PancakeHouseMenuIterator(List<MenuItem> menuItems)
  {
    this.menuItems = menuItems;
  }

  public bool HasNext()
  {
    if (menuItems.Count == 0 || menuItems[menuItems.Count - 1] == null)
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
    var menuItem = menuItems.First();
    menuItems.RemoveAt(0);
    return menuItem;
  }
}