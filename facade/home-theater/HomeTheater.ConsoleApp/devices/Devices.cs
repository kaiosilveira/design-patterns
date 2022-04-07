namespace HomeTheater.ConnectedDevices;

public interface Switchable
{
  void On();
  void Off();
}

public class Screen
{
  public void Up()
  {
    Console.WriteLine("Screen up");
  }

  public void Down()
  {
    Console.WriteLine("Screen down");
  }
}

public class DvdPlayer : Switchable
{
  public void On()
  {
    Console.WriteLine("DvdPlayer is on");
  }

  public void Off()
  {
    Console.WriteLine("DvdPlayer is off");
  }

  public void Play()
  {
    throw new System.NotImplementedException();
  }

  public void Pause()
  {
    throw new System.NotImplementedException();
  }

  public void Stop()
  {
    throw new System.NotImplementedException();
  }
}

public class TheaterLights : Switchable
{
  public void On()
  {
    Console.WriteLine("TheaterLights are on");
  }

  public void Off()
  {

  }

  public void Dim()
  {

  }
}

public class Amplifier : Switchable
{
  public void Off()
  {
    throw new System.NotImplementedException();
  }

  public void On()
  {
    throw new System.NotImplementedException();
  }

  public void SetStereoSound()
  {
    throw new System.NotImplementedException();
  }

  public void SetCD()
  {
    throw new System.NotImplementedException();
  }

  public void SetDVD()
  {
    throw new System.NotImplementedException();
  }

  public void SetSurroundSound()
  {
    throw new System.NotImplementedException();
  }

  public void SetTuner()
  {
    throw new System.NotImplementedException();
  }

  public void SetVolume(int volume)
  {
    throw new System.NotImplementedException();
  }
}

public class Projector : Switchable
{
  public void On()
  {
    throw new System.NotImplementedException();
  }

  public void Off()
  {
    throw new System.NotImplementedException();
  }

  public void WideScreenMode()
  {
    throw new System.NotImplementedException();
  }

  public void TvMode()
  {
    throw new System.NotImplementedException();
  }
}

public class HomeTheaterFacade
{
  void WatchMovie(string name)
  {

  }

  void EndMovie()
  {

  }
}
