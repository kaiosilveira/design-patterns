using ObjectvilleFood.Domain.Utils;

namespace ObjectvilleFood.Domain.MenuDefinition;

public abstract class Menu : Traversable
{
  public abstract void AddItem(MenuItem item);

  public abstract Iterator<MenuItem> CreateIterator();

  public abstract int GetNumberOfItems();
}