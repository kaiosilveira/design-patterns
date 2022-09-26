public class NoScheduleMatchException : Exception
{
  public NoScheduleMatchException() : base(
    message: "No schedule items where found for the provided DateTime"
  )
  { }
}