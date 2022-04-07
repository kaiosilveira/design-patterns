namespace HomeTheater.ConnectedDevices;

public class PopcornPopper : Switchable
{
  public bool IsOn { get; private set; }
  public bool Popping { get; private set; }

  public void On()
  {
    this.IsOn = true;
    Console.WriteLine("Popcorn popper on");
  }

  public void Off()
  {
    this.IsOn = false;
    Console.WriteLine("Popcorn popper off");
  }

  public void Pop()
  {
    this.Popping = true;
    Console.WriteLine("Popcorn popping");
  }
}