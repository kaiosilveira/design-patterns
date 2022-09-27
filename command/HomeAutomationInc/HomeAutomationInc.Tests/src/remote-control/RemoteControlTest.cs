using Xunit;
using HomeAutomationInc.Commands;
using HomeAutomationInc.Remote;
using HomeAutomationInc.Hardware;

namespace HomeAutomationInc.Tests;

class FakeOnCommand : Command
{
  private FakeReceiver receiver;
  public FakeOnCommand(FakeReceiver receiver)
  {
    this.receiver = receiver;
  }

  public void Execute()
  {
    this.receiver.On();
  }

  public void Undo()
  {
    this.receiver.Off();
  }

  public string GetName()
  {
    return "OnCommand";
  }
}

class FakeOffCommand : Command
{
  private FakeReceiver receiver;

  public FakeOffCommand(FakeReceiver receiver)
  {
    this.receiver = receiver;
  }

  public void Execute()
  {
    this.receiver.Off();
  }

  public void Undo()
  {
    this.receiver.On();
  }

  public string GetName()
  {
    return "OffCommand";
  }
}

class FakeReceiver : Switchable
{
  public bool IsOn { get; private set; }

  public void On()
  {
    this.IsOn = true;
  }

  public void Off()
  {
    this.IsOn = false;
  }
}

public class RemoteControlTest
{
  [Fact]
  public void TestStartsWithInstancesOfNoCommandAsDefault()
  {
    var remote = new RemoteControl();

    for (int slot = 0; slot < RemoteControl.REMOTE_SLOTS; slot++)
    {
      var commandsAtSlot = remote.DescribeCommand(slot);
      Assert.Equal("NoCommand", commandsAtSlot[0]);
      Assert.Equal("NoCommand", commandsAtSlot[1]);
    }
  }

  [Fact]
  public void TestAcceptDefiningCommands()
  {
    var remote = new RemoteControl();
    var receiver = new FakeReceiver();

    for (int slot = 0; slot < 7; slot++)
    {
      remote.SetCommand(slot, new FakeOnCommand(receiver), new FakeOffCommand(receiver));
    }

    for (int slot = 0; slot < RemoteControl.REMOTE_SLOTS; slot++)
    {
      var commandsAtSlot = remote.DescribeCommand(slot);
      Assert.Equal("OnCommand", commandsAtSlot[0]);
      Assert.Equal("OffCommand", commandsAtSlot[1]);
    }
  }

  [Fact]
  public void TestExecuteOnCommands()
  {
    var remote = new RemoteControl();
    var receiver1 = new FakeReceiver();
    var receiver2 = new FakeReceiver();
    var receiver3 = new FakeReceiver();
    var receiver4 = new FakeReceiver();
    var receiver5 = new FakeReceiver();
    var receiver6 = new FakeReceiver();
    var receiver7 = new FakeReceiver();
    var onCmd1 = new FakeOnCommand(receiver1);
    var offCmd1 = new FakeOffCommand(receiver1);
    var onCmd2 = new FakeOnCommand(receiver2);
    var offCmd2 = new FakeOffCommand(receiver2);
    var onCmd3 = new FakeOnCommand(receiver3);
    var offCmd3 = new FakeOffCommand(receiver3);
    var onCmd4 = new FakeOnCommand(receiver4);
    var offCmd4 = new FakeOffCommand(receiver4);
    var onCmd5 = new FakeOnCommand(receiver5);
    var offCmd5 = new FakeOffCommand(receiver5);
    var onCmd6 = new FakeOnCommand(receiver6);
    var offCmd6 = new FakeOffCommand(receiver6);
    var onCmd7 = new FakeOnCommand(receiver7);
    var offCmd7 = new FakeOffCommand(receiver7);

    remote.SetCommand(slot: 0, onCmd1, offCmd1);
    remote.OnButtonWasPushed(slot: 0);
    Assert.True(receiver1.IsOn);
    remote.OffButtonWasPushed(slot: 0);
    Assert.False(receiver1.IsOn);

    remote.SetCommand(slot: 1, onCmd2, offCmd2);
    remote.OnButtonWasPushed(slot: 1);
    Assert.True(receiver2.IsOn);
    remote.OffButtonWasPushed(slot: 1);
    Assert.False(receiver2.IsOn);

    remote.SetCommand(slot: 2, onCmd3, offCmd3);
    remote.OnButtonWasPushed(slot: 2);
    Assert.True(receiver3.IsOn);
    remote.OffButtonWasPushed(slot: 2);
    Assert.False(receiver3.IsOn);

    remote.SetCommand(slot: 3, onCmd4, offCmd4);
    remote.OnButtonWasPushed(slot: 3);
    Assert.True(receiver4.IsOn);
    remote.OffButtonWasPushed(slot: 3);
    Assert.False(receiver4.IsOn);

    remote.SetCommand(slot: 4, onCmd5, offCmd5);
    remote.OnButtonWasPushed(slot: 4);
    Assert.True(receiver5.IsOn);
    remote.OffButtonWasPushed(slot: 4);
    Assert.False(receiver4.IsOn);

    remote.SetCommand(slot: 5, onCmd6, offCmd6);
    remote.OnButtonWasPushed(slot: 5);
    Assert.True(receiver6.IsOn);
    remote.OffButtonWasPushed(slot: 5);
    Assert.False(receiver4.IsOn);

    remote.SetCommand(slot: 6, onCmd7, offCmd7);
    remote.OnButtonWasPushed(slot: 6);
    Assert.True(receiver7.IsOn);
    remote.OffButtonWasPushed(slot: 6);
    Assert.False(receiver4.IsOn);
  }

  [Fact]
  public void TestUndo()
  {
    var remote = new RemoteControl();
    var receiver1 = new FakeReceiver();
    var receiver2 = new FakeReceiver();
    var receiver3 = new FakeReceiver();
    var onCmd1 = new FakeOnCommand(receiver1);
    var offCmd1 = new FakeOffCommand(receiver1);
    var onCmd2 = new FakeOnCommand(receiver2);
    var offCmd2 = new FakeOffCommand(receiver2);
    var onCmd3 = new FakeOnCommand(receiver3);
    var offCmd3 = new FakeOffCommand(receiver3);

    remote.SetCommand(0, onCmd1, offCmd1);
    remote.SetCommand(1, onCmd2, offCmd2);
    remote.SetCommand(2, onCmd3, offCmd3);

    remote.OnButtonWasPushed(0);
    remote.OnButtonWasPushed(1);
    remote.OnButtonWasPushed(2);

    remote.Undo();

    Assert.False(receiver3.IsOn);
  }
}