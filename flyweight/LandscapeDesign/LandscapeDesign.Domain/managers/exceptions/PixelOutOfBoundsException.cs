namespace LandscapeDesign.Domain.Managers;

public class PixelOutOfBoundsException : Exception
{
  public PixelOutOfBoundsException(int x, int y)
    : base(message: $"({x}, {y}) is not a valid pixel position for the current screen")
  { }
}