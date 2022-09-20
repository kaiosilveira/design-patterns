using System;
using Xunit;

using Patternsland.Domain.Vacations.Builders;
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
    var parkReservation = new Reservation(
      reservationDate: date,
      ownerIdentification: "1234",
      place: new Park(name: "Patternsland")
    );

    var vacationDay = new VacationDayBuilder()
      .SetDate(date)
      .AddReservation(parkReservation)
      .GetVacationDay();

    var reservationForVacationDay = vacationDay.GetReservationsFor(date);

    Assert.Collection(
      reservationForVacationDay,
      createdReservation =>
      {
        Assert.Equal(createdReservation.Place.Name, parkReservation.Place.Name);
        Assert.Equal(createdReservation.ReservationDate, parkReservation.ReservationDate);
      }
    );
  }

  [Fact]
  public void TestBuildsVacationDayWithMultipleReservations()
  {
    var date = DateTime.Now;
    var builder = new VacationDayBuilder();
    var parkReservation = new Reservation(
      reservationDate: date,
      ownerIdentification: "1234",
      place: new Park(name: "Patternsland")
    );

    var hotelReservation = new Reservation(
      reservationDate: date,
      ownerIdentification: "1234",
      place: new Hotel("Grand Facadian")
    );

    builder.SetDate(date);
    builder.AddReservation(parkReservation);
    builder.AddReservation(hotelReservation);

    var vacationDay = builder.GetVacationDay();

    var reservationForVacationDay = vacationDay.GetReservationsFor(date);

    Assert.Collection(
      reservationForVacationDay,
      firstReservation =>
      {
        Assert.Equal(firstReservation.Place.Name, parkReservation.Place.Name);
        Assert.Equal(firstReservation.ReservationDate, parkReservation.ReservationDate);
      },
      secondReservation =>
      {
        Assert.Equal(secondReservation.Place.Name, hotelReservation.Place.Name);
        Assert.Equal(secondReservation.ReservationDate, hotelReservation.ReservationDate);
      }
    );
  }
}