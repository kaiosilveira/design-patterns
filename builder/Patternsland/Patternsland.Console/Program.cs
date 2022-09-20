using Patternsland.Domain.Reservations;
using Patternsland.Domain.Reservations.ReservableBusinessPlaces;
using Patternsland.Domain.Vacations.Builders;

public class Program
{
  public static void Main(string[] args)
  {
    var firstDay = new DateTime(2022, 9, 20);
    var ownerIdentification = "PP1234";
    var park = new Park(name: "Patternsland");
    var restaurant = new Restaurant(name: "Objectville's Diner");
    var hotel = new Hotel(name: "Grand Facadian");
    var reservationsForFirstDay = new List<Reservation>()
    {
      new Reservation(firstDay, ownerIdentification, place: hotel),
      new Reservation(firstDay, ownerIdentification, place: park),
    };

    var secondDay = new DateTime(2022, 9, 21);
    var reservationsForSecondDay = new List<Reservation>()
    {
      new Reservation(firstDay, ownerIdentification, place: hotel),
      new Reservation(firstDay, ownerIdentification, place: restaurant),
    };

    var builder = new VacationBuilder();
    builder.AddReservationsForDay(firstDay, reservationsForFirstDay);
    builder.AddReservationsForDay(secondDay, reservationsForSecondDay);

    var planner = builder.GetVacationPlanner();

    Console.WriteLine($"Vacation days planned: {planner.VacationDays.Count}");
    planner.VacationDays.ToList().ForEach(day =>
    {
      Console.WriteLine($"\t{day.Date.ToShortDateString()}: {day.Reservations.Count} reservations");
      day.Reservations.ToList().ForEach(reservation =>
      {
        Console.WriteLine($"\t\tPlace: {reservation.Place.Name} | Owner identification: {reservation.OwnerIdentification}");
      });
    });
  }
}