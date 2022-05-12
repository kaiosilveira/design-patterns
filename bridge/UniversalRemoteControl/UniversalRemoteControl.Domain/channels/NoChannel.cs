namespace UniversalRemoteControl.Domain;

public class NoChannel : TVChannel
{
  public NoChannel() : base(number: 0, label: "No channel selected") { }
}
