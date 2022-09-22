namespace LandscapeDesign.Domain.Managers;

public class InvalidMatrixBoundsException : Exception
{
  public InvalidMatrixBoundsException()
    : base(message: "Invalid matrix size provided for Landscape Manager")
  { }
}