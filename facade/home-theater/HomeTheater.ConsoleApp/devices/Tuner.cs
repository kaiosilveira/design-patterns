namespace HomeTheater.ConnectedDevices;

public enum TunerMode
{
  AM,
  FM,
  CD,
  DVD
}

public class Tuner : Switchable
{
  public TunerMode Mode { get; private set; }
  public double Frequency { get; private set; }
  public bool IsOn { get; private set; }

  public void SetAM()
  {
    this.Mode = TunerMode.AM;
    Console.WriteLine("Tuner set to AM");
  }

  public void SetFM()
  {
    this.Mode = TunerMode.FM;
    Console.WriteLine("Tuner set to FM");
  }

  public void SetFrequency(double frequency)
  {
    this.Frequency = frequency;
    Console.WriteLine("Tuner set to {0}", frequency);
  }

  public void On()
  {
    this.IsOn = true;
    Console.WriteLine("Tuner on");
  }

  public void Off()
  {
    this.IsOn = false;
    Console.WriteLine("Tuner off");
  }
}
