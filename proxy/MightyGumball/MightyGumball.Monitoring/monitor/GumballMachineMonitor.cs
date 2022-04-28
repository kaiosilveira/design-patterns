

using MightyGumball.Monitoring.Machines;

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
    var location = this.machine.GetLocation();
    var count = this.machine.GetGumballCount();
    return $"Gumball Machine: {location} | Current Inventory: {count}";
  }
}