using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace Patternsland.DomainTests;

class Planner
{
  public IList<VacationDay> VacationDays { get; private set; }

  public Planner(IList<VacationDay> vacationDays)
  {
    this.VacationDays = vacationDays;
  }
}

abstract class ReservableBusinessPlace
{
  public readonly string Name;

  public ReservableBusinessPlace(string name)
  {
    this.Name = name;
  }
}

class Hotel : ReservableBusinessPlace
{
  public Hotel(string name) : base(name) { }
}

class Park : ReservableBusinessPlace
{
  public Park(string name) : base(name) { }
}

abstract class Reservation
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

class ParkReservation : Reservation
{
  public readonly string ParkName;

  public ParkReservation(
    DateTime reservationDate,
    string ownerIdentification,
    string parkName) : base(reservationDate, ownerIdentification, new Park(parkName))
  {
    this.ParkName = parkName;
  }
}

class SpecialEvent
{
  public readonly string Name;
  public readonly DateTime Date;

  public SpecialEvent(string name, DateTime date)
  {
    this.Name = name;
    this.Date = date;
  }
}

class Dinner
{
  public IList<string> Meals { get; private set; }

  public Dinner(IList<string> meals)
  {
    this.Meals = meals;
  }
}

class VacationDay
{
  public readonly DateTime Date;
  public readonly IList<Reservation> Reservations;

  public VacationDay(DateTime date, IList<Reservation> reservations)
  {
    this.Date = date;
    this.Reservations = reservations;
  }

  public IEnumerable<Reservation> GetReservationsFor(DateTime date)
  {
    return this.Reservations.Where(r => r.ReservationDate.Equals(date));
  }
}

interface IVacationBuilder
{
  void AddReservationsForDay(DateTime date, IList<Reservation> reservations);

  Planner GetVacationPlanner();
}

interface IVacationDayBuilder
{
  void AddReservation(Reservation reservation);
}

class VacationDayBuilder : IVacationDayBuilder
{
  public IList<Reservation> Reservations { get; private set; }
  public DateTime Date { get; private set; }

  public VacationDayBuilder()
  {
    this.Reservations = new List<Reservation>();
  }

  public void SetDate(DateTime date)
  {
    this.Date = date;
  }

  public void AddReservation(Reservation reservation)
  {
    this.Reservations.Add(reservation);
  }

  public VacationDay GetVacationDay()
  {
    return new VacationDay(this.Date, this.Reservations);
  }
}

class Client
{
  private readonly IVacationBuilder vacationBuilder;

  public Client(IVacationBuilder vacationBuilder)
  {
    this.vacationBuilder = vacationBuilder;
  }

  Planner ConstructPlanner()
  {
    return this.vacationBuilder.GetVacationPlanner();
  }
}

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
      parkName: "Patternsland"
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