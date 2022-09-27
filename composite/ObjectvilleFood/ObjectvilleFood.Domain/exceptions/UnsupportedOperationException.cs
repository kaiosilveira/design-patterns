namespace ObjectvilleFood.Domain.Exceptions;

public class UnsupportedOperationException : System.Exception
{
  public UnsupportedOperationException() : base("The requested operation is not supported") { }
}