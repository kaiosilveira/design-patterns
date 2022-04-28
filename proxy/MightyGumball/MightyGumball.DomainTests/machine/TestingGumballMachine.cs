using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.Domain.Machine;

namespace MightyGumball.DomainTests.Machine;

class TestingGumballMachine : GumballMachine
{
  public TestingGumballMachine(int gumballCount = 5) : base(gumballCount) { }

  public GumballMachineState GetState()
  {
    return this.state;
  }
}