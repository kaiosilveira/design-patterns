using System;
using Xunit;

using Patternsland.Domain.Reservations;
using Patternsland.Domain.Reservations.ReservableBusinessPlaces;

public class ReservationTest
{
  [Fact]
  public void TestHasDate()
  {
    var reservationDate = DateTime.Now;
    var ownerIdentification = "1234";
    var park = new Park(name: "Patternsland");
    var reservation = new Reservation(reservationDate, ownerIdentification, park);

    Assert.Equal(reservationDate, reservation.ReservationDate);
    Assert.Equal(ownerIdentification, reservation.OwnerIdentification);
    Assert.Equal(park.Name, reservation.Place.Name);
  }
}
