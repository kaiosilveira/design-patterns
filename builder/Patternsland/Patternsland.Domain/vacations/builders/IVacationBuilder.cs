using Patternsland.Domain.Reservations;

namespace Patternsland.Domain;

public interface IVacationBuilder
{
  void AddReservationsForDay(DateTime date, IList<Reservation> reservations);

  VacationPlanner GetVacationPlanner();
}
