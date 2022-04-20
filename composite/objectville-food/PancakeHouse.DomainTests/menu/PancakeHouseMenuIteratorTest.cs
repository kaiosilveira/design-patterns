using Xunit;
using System.Collections.Generic;
using PancakeHouse.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;
using ObjectvilleFood.Domain.Exceptions;

public class PancakeHouseMenuIteratorTest
{
  [Fact]
  public void TestEmptySet()
  {
    var iterator = new PancakeHouseMenuIterator(new List<MenuItem>());
    Assert.False(iterator.HasNext());
  }

  [Fact]
  public void TestIteration()
  {
    var item1 = new MenuItem("item1", "description1", isVegetarian: false, price: 299);
    var item2 = new MenuItem("item2", "description2", isVegetarian: true, price: 399);

    var iterator = new PancakeHouseMenuIterator(new List<MenuItem>() { item1, item2 });

    Assert.True(iterator.HasNext());
    Assert.Equal(item1.Name, iterator.Next().Name);

    Assert.True(iterator.HasNext());
    Assert.Equal(item2.Name, iterator.Next().Name);

    Assert.False(iterator.HasNext());
  }

  [Fact]
  public void TestThrowsIfOutOfBounds()
  {
    var iterator = new PancakeHouseMenuIterator(new List<MenuItem>());
    Assert.Throws<IteratorOutOfBoundsException>(() => iterator.Next());
  }
}