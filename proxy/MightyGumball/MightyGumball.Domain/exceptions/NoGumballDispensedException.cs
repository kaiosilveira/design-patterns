namespace MightyGumball.Domain.Exceptions;

public class NoGumballDispensedException : Exception
{
  public NoGumballDispensedException() : base(message: "No gumball dispensed") { }
}