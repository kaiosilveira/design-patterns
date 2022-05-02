namespace ObjectvilleMatchmaking.Domain.Exceptions;

public class IllegalInvocationException : Exception
{
  public IllegalInvocationException() : base(message: "Illegal invocation") { }
}
