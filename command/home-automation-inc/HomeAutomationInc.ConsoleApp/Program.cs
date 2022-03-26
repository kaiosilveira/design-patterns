using HomeAutomationInc.Commands;
using HomeAutomationInc.Hardware;
using HomeAutomationInc.Remote;

namespace HomeAutomationInc.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var remote = new RemoteControl();
    var livingRoomLight = new Light();
    var kitchenLight = new Light();
    var ceilingFan = new CeilingFan();
    var garageDoor = new GarageDoor();
    var stereo = new Stereo();

    remote.SetCommand(0, new LightOnCommand(livingRoomLight), new LightOffCommand(livingRoomLight));
    remote.SetCommand(1, new LightOnCommand(kitchenLight), new LightOffCommand(kitchenLight));
    remote.SetCommand(2, new CeilingFanOnCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));
    remote.SetCommand(3, new StereoOnWithCDCommand(stereo), new StereoOffCommand(stereo));

    for (int i = 0; i < RemoteControl.REMOTE_SLOTS; i++)
    {
      var description = remote.DescribeCommand(i);
      Console.WriteLine($"[slot {i}] OnCmd: {description[0]} \t\t\t OffCmd: {description[1]}");
    }
  }
}