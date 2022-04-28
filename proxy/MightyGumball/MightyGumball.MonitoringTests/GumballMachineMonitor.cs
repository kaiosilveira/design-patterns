using Xunit;
using MightyGumball.Domain.Machine;

namespace MightyGumball.MonitoringTests;

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

public class GumballMachineMonitorTest
{
  [Fact]
  public void TestCreateReport()
  {
    var machine = new GumballMachine(location: "Lisbon", gumballCount: 100);
    var monitor = new GumballMachineMonitor(machine);

    var report = monitor.CreateReport();

    Assert.Equal("Gumball Machine: Lisbon | Current Inventory: 100", report);
  }
}