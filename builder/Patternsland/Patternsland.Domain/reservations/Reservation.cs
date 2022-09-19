namespace Patternsland.Domain;

public abstract class Reservation
{
  public readonly DateTime ReservationDate;
  public readonly string OwnerIdentification;
  public readonly ReservableBusinessPlace Place;

  public Reservation(DateTime reservationDate, string ownerIdentification, ReservableBusinessPlace place)
  {
    this.ReservationDate = reservationDate;
    this.OwnerIdentification = ownerIdentification;
    this.Place = place;
  }
}