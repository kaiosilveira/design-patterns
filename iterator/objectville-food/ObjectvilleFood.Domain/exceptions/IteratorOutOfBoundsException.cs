namespace ObjectvilleFood.Domain.Exceptions;

public class IteratorOutOfBoundsException : Exception
{
  public IteratorOutOfBoundsException() : base("Iterator is out of bounds") { }
}