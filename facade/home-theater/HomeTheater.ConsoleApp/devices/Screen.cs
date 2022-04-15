namespace HomeTheater.ConnectedDevices;

public enum ScreenPosition
{
  Up,
  Down
}

public class Screen
{
  public ScreenPosition Position { get; private set; }

  public void Up()
  {
    Console.WriteLine("Theater screen is going up");
    this.Position = ScreenPosition.Up;
  }

  public void Down()
  {
    Console.WriteLine("Theater screen is going down");
    this.Position = ScreenPosition.Down;
  }
}