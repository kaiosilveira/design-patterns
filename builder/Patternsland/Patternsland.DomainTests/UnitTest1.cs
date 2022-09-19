using System;
using System.Linq;
using Xunit;
using Patternsland.Domain;
using Patternsland.Domain.Reservations;
using Patternsland.Domain.Reservations.ReservableBusinessPlaces;

namespace Patternsland.DomainTests;

public class VacationDayBuilderTest
{
  [Fact]
  public void TestBuildsVacationDayForTheSpecifiedDate()
  {
    var date = DateTime.Now;
    var builder = new VacationDayBuilder();

    builder.SetDate(date);
    var vacationDay = builder.GetVacationDay();

    Assert.Equal(date, vacationDay.Date);
  }

  [Fact]
  public void TestBuildsVacationDayWithOneReservation()
  {
    var date = DateTime.Now;
    var builder = new VacationDayBuilder();
    var parkReservation = new ParkReservation(
      reservationDate: date,
      ownerIdentification: "1234",
      park: new Park(name: "Patternsland")
    );

    builder.SetDate(date);
    var hotel = new Hotel(name: "Grand Facadian");
    builder.AddReservation(parkReservation);

    var vacationDay = builder.GetVacationDay();

    var reservationForVacationDay = vacationDay.GetReservationsFor(date);
    Assert.Equal(1, reservationForVacationDay.Count());

    var createdReservation = reservationForVacationDay.First();
    Assert.Equal(createdReservation.Place.Name, parkReservation.Place.Name);
    Assert.Equal(createdReservation.ReservationDate, parkReservation.ReservationDate);
  }
}