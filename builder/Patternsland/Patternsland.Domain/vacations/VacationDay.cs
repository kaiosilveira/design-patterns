using Patternsland.Domain.Reservations;

namespace Patternsland.Domain.Vacations;

public class VacationDay
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
