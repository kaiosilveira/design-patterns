
using Patternsland.Domain.Reservations;

namespace Patternsland.Domain;

public interface IVacationDayBuilder
{
  void AddReservation(Reservation reservation);
}
