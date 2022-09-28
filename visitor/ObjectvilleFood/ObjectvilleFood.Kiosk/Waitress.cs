using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleFood.Kiosk;

public class Waitress
{
  private MenuComponent allMenus;

  public Waitress(MenuComponent menus)
  {
    this.allMenus = menus;
  }

  public void PrintMenu()
  {
    allMenus.Print();
  }
}