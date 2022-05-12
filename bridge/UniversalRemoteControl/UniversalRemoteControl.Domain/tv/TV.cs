namespace UniversalRemoteControl.Domain;

public interface TV
{
  void On();
  void Off();
  void TuneChannel(TVChannel channel);
}
