namespace Patternsland.Domain;

public class ParkReservation : Reservation
{
  public ParkReservation(
    DateTime reservationDate,
    string ownerIdentification,
    Park park) : base(reservationDate, ownerIdentification, park) { }
}
