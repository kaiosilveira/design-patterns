
using Patternsland.Domain.Reservations;

namespace Patternsland.Domain;

public interface IVacationDayBuilder
{
  IVacationDayBuilder AddReservation(Reservation reservation);
  IVacationDayBuilder SetDate(DateTime date);
  VacationDay GetVacationDay();
}
