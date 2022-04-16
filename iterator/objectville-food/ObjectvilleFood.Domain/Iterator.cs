namespace ObjectvilleFood.Domain;

public interface Iterator<T>
{
  bool HasNext();

  T Next();
}
