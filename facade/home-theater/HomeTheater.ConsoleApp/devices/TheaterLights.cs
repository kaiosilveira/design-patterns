namespace HomeTheater.ConnectedDevices;

public class DeviceOffException : Exception
{
  public DeviceOffException() : base(
    "Cannot perform the requested action because the device is currently off. Please call .On() first"
  )
  { }
}

public class TheaterLights : Switchable
{
  public bool IsOn { get; private set; }
  public int Brightness { get; private set; }

  public void On()
  {
    this.IsOn = true;
    Console.WriteLine("TheaterLights are on");
  }

  public void Off()
  {
    this.IsOn = false;
    Console.WriteLine("TheaterLights are off");
  }

  public void Dim(int level)
  {
    if (!this.IsOn)
    {
      throw new DeviceOffException();
    }

    this.Brightness = level;
    Console.WriteLine($"Brightness set to {level}");
  }
}