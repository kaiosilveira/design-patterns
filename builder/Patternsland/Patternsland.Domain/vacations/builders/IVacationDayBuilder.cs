
using Patternsland.Domain.Reservations;

namespace Patternsland.Domain.Vacations.Builders;

public interface IVacationDayBuilder
{
  IVacationDayBuilder AddReservation(Reservation reservation);
  IVacationDayBuilder SetDate(DateTime date);
  VacationDay GetVacationDay();
}
