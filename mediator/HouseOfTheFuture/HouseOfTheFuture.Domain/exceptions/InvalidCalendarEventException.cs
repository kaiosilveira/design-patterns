public class InvalidCalendarEventException : Exception
{
  public InvalidCalendarEventException() : base(message: "Invalid calendar event") { }
}