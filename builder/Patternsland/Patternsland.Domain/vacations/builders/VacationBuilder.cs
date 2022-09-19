using Patternsland.Domain.Reservations;

namespace Patternsland.Domain;

public class VacationBuilder : IVacationBuilder
{
  private IList<VacationDay> vacationDays;

  public VacationBuilder()
  {
    this.vacationDays = new List<VacationDay>();
  }

  public void AddReservationsForDay(DateTime date, IList<Reservation> reservations)
  {
    var dayBuilder = new VacationDayBuilder();
    reservations.ToList().ForEach(reservation => dayBuilder.AddReservation(reservation));

    this.vacationDays.Add(dayBuilder.GetVacationDay());
  }

  public VacationPlanner GetVacationPlanner()
  {
    return new VacationPlanner(this.vacationDays);
  }
}