using Patternsland.Domain.Reservations;

namespace Patternsland.Domain.Vacations.Builders;

public interface IVacationBuilder
{
  void AddReservationsForDay(DateTime date, IList<Reservation> reservations);

  VacationPlanner GetVacationPlanner();
}
