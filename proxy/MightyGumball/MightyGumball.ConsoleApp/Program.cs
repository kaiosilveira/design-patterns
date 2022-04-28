using MightyGumball.Monitoring;
using MightyGumball.Monitoring.Machines;

namespace MightyGumball.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var handler = new StaticHttpClientHandler(new List<string>() { "Lisbon", "100" });
    var machine = new RemoteGumballMachine(id: "lisbon-machine", http: new HttpClient(handler));
    var monitor = new GumballMachineMonitor(machine);

    Console.WriteLine(monitor.CreateReport());
  }
}