namespace LandscapeDesign.Domain.Screens;

public class ScreenRect
{
  public int XLength { get; private set; }
  public int YLength { get; private set; }

  public ScreenRect(int xLength, int yLength)
  {
    this.XLength = xLength;
    this.YLength = yLength;
  }
}