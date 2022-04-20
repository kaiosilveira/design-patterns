namespace ObjectvilleFood.Domain.Utils;

public interface Iterator<T>
{
  bool HasNext();

  T Next();
}
