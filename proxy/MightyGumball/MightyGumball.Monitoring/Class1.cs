using MightyGumball.Domain.Machine;

namespace MightyGumball.Monitoring;

public class GumballMachineMonitor
{
  private GumballMachine machine;

  public GumballMachineMonitor(GumballMachine machine)
  {
    this.machine = machine;
  }

  public string CreateReport()
  {
    var location = this.machine.Location;
    var count = this.machine.GumballCount;
    return $"Gumball Machine: {this.machine.Location} | Current Inventory: {count}";
  }
}