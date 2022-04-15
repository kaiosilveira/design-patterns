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
    this.Position = ScreenPosition.Up;
  }

  public void Down()
  {
    this.Position = ScreenPosition.Down;
  }
}