namespace UniversalRemoteControl.Domain;

public class TVChannel
{
  public int Number { get; private set; }
  public string Label { get; private set; }

  public TVChannel(int number, string label)
  {
    this.Number = number;
    this.Label = label;
  }
}
