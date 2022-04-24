namespace MightyGumball.Domain.Exceptions;

public class GumballBeingSoldException : Exception
{
  public GumballBeingSoldException()
    : base(message: "Please wait until the current gumball finishes being sold") { }
}