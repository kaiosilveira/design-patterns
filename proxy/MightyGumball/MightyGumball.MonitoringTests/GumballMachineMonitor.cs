using Xunit;
using MightyGumball.Domain.Machine;
using MightyGumball.Monitoring;

namespace MightyGumball.MonitoringTests;

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