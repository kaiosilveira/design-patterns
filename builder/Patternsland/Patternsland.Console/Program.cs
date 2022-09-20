using Patternsland.Domain.Reservations;
using Patternsland.Domain.Reservations.ReservableBusinessPlaces;
using Patternsland.Domain.Vacations.Builders;

public class Program
{
  public static void Main(string[] args)
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
  }
}