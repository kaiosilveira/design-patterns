
using HomeAutomationInc.Commands;

namespace HomeAutomationInc.Remote;

public class RemoteControl
{
  public static readonly int REMOTE_SLOTS = 7;
  Command[] onCommands;
  Command[] offCommands;
  Command lastCommand;

  public RemoteControl()
  {
    onCommands = new Command[RemoteControl.REMOTE_SLOTS];
    offCommands = new Command[RemoteControl.REMOTE_SLOTS];

    var noCommand = new NoCommand();
    lastCommand = noCommand;
    for (int i = 0; i < RemoteControl.REMOTE_SLOTS; i++)
    {
      onCommands[i] = noCommand;
      offCommands[i] = noCommand;
    }
  }

  public void SetCommand(int slot, Command onCommand, Command offCommand)
  {
    this.onCommands[slot] = onCommand;
    this.offCommands[slot] = offCommand;
  }

  public void OnButtonWasPushed(int slot)
  {
    this.onCommands[slot].Execute();
    this.lastCommand = this.onCommands[slot];
  }

  public void OffButtonWasPushed(int slot)
  {
    this.offCommands[slot].Execute();
    this.lastCommand = this.offCommands[slot];
  }

  public string[] DescribeCommand(int slot)
  {
    return new string[] { this.onCommands[slot].GetName(), this.offCommands[slot].GetName() };
  }

  public void Undo()
  {
    this.lastCommand.Undo();
  }
}
