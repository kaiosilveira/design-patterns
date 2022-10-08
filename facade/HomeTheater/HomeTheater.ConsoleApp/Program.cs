using HomeTheater.ConnectedDevices;
using HomeTheater.Facade;

namespace HomeTheater.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var homeTheaterFacade = new HomeTheaterFacade(
      new PopcornPopper(),
      new TheaterLights(),
      new Screen(),
      new Projector(),
      new DVDPlayer(),
      new Amplifier()
    );

    homeTheaterFacade.WatchMovie("Fight Club");
    homeTheaterFacade.EndMovie();
  }
}