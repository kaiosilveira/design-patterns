using Xunit;
using ObjectvilleDiner.Domain.MenuDefinition;
using ObjectvilleFood.Domain.MenuDefinition;

public class DinerMenuIteratorTest
{
  [Fact]
  public void TestEmptySet()
  {
    var iterator = new DinerMenuIterator(new MenuItem[] { });
    Assert.False(iterator.HasNext());
  }

  [Fact]
  public void TestReturnsTheNextItem()
  {
    var item1 = new MenuItem("item1", "description1", isVegetarian: false, price: 299);
    var item2 = new MenuItem("item2", "description3", isVegetarian: true, price: 399);

    var iterator = new DinerMenuIterator(new MenuItem[] { item1, item2 });

    Assert.True(iterator.HasNext());
    Assert.Equal(item1.Name, iterator.Next().Name);

    Assert.True(iterator.HasNext());
    Assert.Equal(item2.Name, iterator.Next().Name);

    Assert.False(iterator.HasNext());
  }
}