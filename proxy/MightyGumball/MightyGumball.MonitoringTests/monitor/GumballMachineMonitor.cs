using Xunit;
using MightyGumball.Monitoring;
using MightyGumball.Monitoring.Machines;

namespace MightyGumball.MonitoringTests;

class TestingGumballMachine : GumballMachine
{
  private string location;
  private int gumballCount;

  public TestingGumballMachine(string location, int gumballCount)
  {
    this.location = location;
    this.gumballCount = gumballCount;
  }

  public int GetGumballCount()
  {
    return this.gumballCount;
  }

  public string GetLocation()
  {
    return this.location;
  }
}

public class GumballMachineMonitorTest
{
  [Fact]
  public void TestCreateReport()
  {
    var machine = new TestingGumballMachine(location: "Lisbon", gumballCount: 100);
    var monitor = new GumballMachineMonitor(machine);

    var report = monitor.CreateReport();

    Assert.Equal("Gumball Machine: Lisbon | Current Inventory: 100", report);
  }
}