namespace HouseOfTheFuture.Domain.Exceptions;

public class InvalidCalendarEventException : Exception
{
  public InvalidCalendarEventException() : base(message: "Invalid calendar event") { }
}