namespace MightyGumball.Domain.Exceptions;

public class CrankAlreadyTurnedException : Exception
{
  public CrankAlreadyTurnedException() : base(message: "Sorry, you've already turned the crank") { }
}