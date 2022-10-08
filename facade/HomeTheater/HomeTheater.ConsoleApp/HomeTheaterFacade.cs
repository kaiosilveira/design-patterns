using HomeTheater.ConnectedDevices;

namespace HomeTheater.Facade;

public class HomeTheaterFacade
{
  private PopcornPopper _popper { get; set; }
  private TheaterLights _lights { get; set; }
  private Screen _screen { get; set; }
  private Projector _projector { get; set; }
  private DVDPlayer _dvd { get; set; }
  private Amplifier _amp { get; set; }

  public HomeTheaterFacade(PopcornPopper popper, TheaterLights lights, Screen screen, Projector projector, DVDPlayer dvd, Amplifier amp)
  {
    _popper = popper;
    _lights = lights;
    _screen = screen;
    _projector = projector;
    _dvd = dvd;
    _amp = amp;
  }

  public void WatchMovie(string name)
  {
    Console.WriteLine("Get ready to watch a movie...");
    _popper.On();
    _popper.Pop();
    _lights.On();
    _lights.Dim(10);
    _screen.Down();
    _projector.On();
    _projector.WideScreenMode();
    _amp.On();
    _amp.SetDVD(_dvd);
    _amp.SetSurroundSound();
    _amp.SetVolume(5);
    _dvd.On();
    _dvd.Play(name);
  }

  public void EndMovie()
  {
    Console.WriteLine("Shutting movie theater down...");
    _popper.Off();
    _lights.Off();
    _screen.Up();
    _projector.Off();
    _amp.Off();
    _dvd.Stop();
    _dvd.Eject();
    _dvd.Off();
  }
}
