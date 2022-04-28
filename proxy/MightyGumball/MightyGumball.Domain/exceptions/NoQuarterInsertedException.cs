namespace MightyGumball.Domain.Exceptions;

public class NoQuarterInsertedException : Exception
{
  public NoQuarterInsertedException()
    : base(message: "Operation cannot be performed because no quarter was inserted") { }
}