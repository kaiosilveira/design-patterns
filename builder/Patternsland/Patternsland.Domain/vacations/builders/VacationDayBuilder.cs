using Patternsland.Domain.Reservations;

namespace Patternsland.Domain.Vacations.Builders;

public class VacationDayBuilder : IVacationDayBuilder
{
  public IList<Reservation> Reservations { get; private set; }
  public DateTime Date { get; private set; }

  public VacationDayBuilder()
  {
    this.Reservations = new List<Reservation>();
  }

  public IVacationDayBuilder SetDate(DateTime date)
  {
    this.Date = date;
    return this;
  }

  public IVacationDayBuilder AddReservation(Reservation reservation)
  {
    this.Reservations.Add(reservation);
    return this;
  }

  public VacationDay GetVacationDay()
  {
    return new VacationDay(this.Date, this.Reservations);
  }
}
