namespace HouseOfTheFuture.Domain.Exceptions;

public class InvalidDateTimeTickException : Exception
{
  public InvalidDateTimeTickException() : base(
    message: "The provided DateTime is invalid and therefore cannot represent a clock tick"
  )
  { }
}