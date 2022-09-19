using System;
using System.Collections.Generic;
using Patternsland.Domain;
using Patternsland.Domain.Reservations;
using Patternsland.Domain.Reservations.ReservableBusinessPlaces;
using Xunit;

public class VacationBuilderTest
{
  [Fact]
  public void TestCreatesAnEmptyPlanner()
  {
    var planner = new VacationBuilder().GetVacationPlanner();
    Assert.Empty(planner.VacationDays);
  }

  [Fact]
  public void TestCreatesPlannerWithReservation()
  {
    var date = DateTime.Now;
    var ownerIdentification = "PP1234";
    var park = new Park(name: "Patternsland");
    var hotel = new Hotel(name: "Grand Facadian");
    var reservations = new List<Reservation>()
    {
      new Reservation(date, ownerIdentification, place: park),
      new Reservation(date, ownerIdentification, place: hotel),
    };

    var builder = new VacationBuilder();
    builder.AddReservationsForDay(date, reservations);

    var planner = builder.GetVacationPlanner();

    Assert.Single(planner.VacationDays);

    var vacationDay = planner.VacationDays[0];
    Assert.Collection(
      vacationDay.Reservations,
      firstReservation =>
      {
        Assert.Equal(date, firstReservation.ReservationDate);
        Assert.Equal(ownerIdentification, firstReservation.OwnerIdentification);
        Assert.Equal(park.Name, firstReservation.Place.Name);
      },
      secondReservation =>
      {
        Assert.Equal(date, secondReservation.ReservationDate);
        Assert.Equal(ownerIdentification, secondReservation.OwnerIdentification);
        Assert.Equal(hotel.Name, secondReservation.Place.Name);
      }
    );
  }
}