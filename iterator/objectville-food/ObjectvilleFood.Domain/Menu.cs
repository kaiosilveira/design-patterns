using ObjectvilleFood.Domain.Utils;

namespace ObjectvilleFood.Domain.MenuDefinition;

public interface Menu
{
  Iterator<MenuItem> CreateIterator();
}