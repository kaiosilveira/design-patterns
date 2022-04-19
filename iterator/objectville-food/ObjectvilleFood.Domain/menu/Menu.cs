namespace ObjectvilleFood.Domain.MenuDefinition;

public abstract class Menu
{
  public abstract void AddItem(MenuItem item);
  public abstract int GetNumberOfItems();
}