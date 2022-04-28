namespace MightyGumball.Domain.Exceptions;

public class QuarterAlreadyInsertedException : Exception
{
  public QuarterAlreadyInsertedException() : base(message: "You cannot insert another quarter") { }
}
