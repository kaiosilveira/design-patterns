using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleFood.Domain.Utils;

public interface Traversable
{
  Iterator<MenuItem> CreateIterator();
}