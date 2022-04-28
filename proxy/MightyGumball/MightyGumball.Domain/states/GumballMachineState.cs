namespace MightyGumball.Domain.GumballMachineStates;

public interface GumballMachineState
{
  void InsertQuarter();

  void EjectQuarter();

  void TurnCrank();

  void Dispense();
}