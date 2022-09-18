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

public class ParkReservation : Reservation
{
  public ParkReservation(
    DateTime reservationDate,
    string ownerIdentification,
    Park park) : base(reservationDate, ownerIdentification, park) { }
}

public abstract class ReservableBusinessPlace
{
  public readonly string Name;

  public ReservableBusinessPlace(string name)
  {
    this.Name = name;
  }
}

public class Hotel : ReservableBusinessPlace
{
  public Hotel(string name) : base(name) { }
}

public class Park : ReservableBusinessPlace
{
  public Park(string name) : base(name) { }
}

public class SpecialEvent : ReservableBusinessPlace
{
  public readonly DateTime Date;

  public SpecialEvent(string name, DateTime date) : base(name)
  {
    this.Date = date;
  }
}

public class Restaurant : ReservableBusinessPlace
{
  public Restaurant(string name) : base(name) { }
}
