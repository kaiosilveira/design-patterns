using ObjectvilleFood.Domain.MenuDefinition;

namespace PancakeHouse.Domain.MenuDefinition;

public class PancakeHouseMenu : Menu
{
  public PancakeHouseMenu()
    : base(name: "Breakfast Menu", description: "Pancake House's breakfast Menu")
  {
    this.Add(
      new MenuItem(
        name: "K&B's Pancake Breakfast",
        description: "Pancakes with scrambled eggs, and toast",
        isVegetarian: true,
        price: 299,
        proteinInGams: 15.6,
        carbohydratesInGrams: 95.3,
        fatInGrams: 32.2
      )
    );

    this.Add(
      new MenuItem(
        name: "Regular Pancake Breakfast",
        description: "Pancakes with fried eggs, sausage",
        isVegetarian: false,
        price: 299,
        proteinInGams: 19.6,
        carbohydratesInGrams: 95.3,
        fatInGrams: 150.2
      )
    );

    this.Add(
      new MenuItem(
        name: "Blueberry Pancakes",
        description: "Pancakes made with fresh blueberries",
        isVegetarian: true,
        price: 349,
        proteinInGams: 5.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 20.2
      )
    );

    this.Add(
      new MenuItem(
        name: "Waffles",
        description: "Waffles, with your choice of blueberries or strawberries",
        isVegetarian: true,
        price: 359,
        proteinInGams: 3.6,
        carbohydratesInGrams: 125.3,
        fatInGrams: 63.2
      )
    );
  }
}