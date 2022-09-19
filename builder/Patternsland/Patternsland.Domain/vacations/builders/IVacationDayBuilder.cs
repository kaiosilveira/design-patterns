
using Patternsland.Domain.Reservations;

namespace Patternsland.Domain;

public interface IVacationDayBuilder
{
  void AddReservation(Reservation reservation);
  void SetDate(DateTime date);
  VacationDay GetVacationDay();
}
