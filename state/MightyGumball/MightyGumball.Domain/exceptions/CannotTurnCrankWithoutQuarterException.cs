namespace MightyGumball.Domain.Exceptions;

public class CannotTurnCrankWithoutQuarterException : Exception
{
  public CannotTurnCrankWithoutQuarterException()
    : base(message: "You cannot turn the crank as no quarter was inserted") { }
}
