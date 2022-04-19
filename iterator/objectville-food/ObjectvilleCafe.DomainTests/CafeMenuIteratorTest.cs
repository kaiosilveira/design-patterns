using Xunit;
using ObjectvilleCafe.Domain;
using System.Collections.Generic;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Exceptions;

public class CafeMenuIteratorTest
{
  [Fact]
  public void TestEmptySet()
  {
    var iterator = new CafeMenuIterator(new Dictionary<string, MenuItem>());
    Assert.False(iterator.HasNext());
  }

  [Fact]
  public void TestIteration()
  {
    var item1 = new MenuItem(name: "item1", description: "item2", isVegetarian: true, price: 399);
    var item2 = new MenuItem(name: "item2", description: "item2", isVegetarian: false, price: 299);
    var items = new Dictionary<string, MenuItem>();
    items.Add(item1.Name, item1);
    items.Add(item2.Name, item2);

    var iterator = new CafeMenuIterator(items);
    Assert.True(iterator.HasNext());
    Assert.Equal(item1.Name, iterator.Next().Name);

    Assert.True(iterator.HasNext());
    Assert.Equal(item2.Name, iterator.Next().Name);

    Assert.False(iterator.HasNext());
  }

  [Fact]
  public void TestThrowsIfOutOfBounds()
  {
    var iterator = new CafeMenuIterator(new Dictionary<string, MenuItem>());
    Assert.Throws<IteratorOutOfBoundsException>(() => iterator.Next());
  }
}