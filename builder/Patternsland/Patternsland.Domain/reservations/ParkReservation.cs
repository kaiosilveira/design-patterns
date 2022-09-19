using Patternsland.Domain.Reservations.ReservableBusinessPlaces;

namespace Patternsland.Domain.Reservations;

public class ParkReservation : Reservation
{
  public ParkReservation(
    DateTime reservationDate,
    string ownerIdentification,
    Park park) : base(reservationDate, ownerIdentification, park) { }
}
