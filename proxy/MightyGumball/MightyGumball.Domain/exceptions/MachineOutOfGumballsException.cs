namespace MightyGumball.Domain.Exceptions;

public class MachineOutOfGumballsException : Exception
{
  public MachineOutOfGumballsException() : base(message: "The machine is out of gumballs.") { }
}