using MightyGumball.Domain.GumballMachineStates;
using MightyGumball.Domain.Machine;

namespace MightyGumball.DomainTests.Machine;

class TestingGumballMachine : GumballMachine
{
  public TestingGumballMachine(string location, int gumballCount = 5) : base(location, gumballCount) { }

  public GumballMachineState GetState()
  {
    return this.state;
  }
}