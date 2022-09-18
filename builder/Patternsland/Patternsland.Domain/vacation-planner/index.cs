namespace Patternsland.Domain;

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

public interface IVacationBuilder
{
  void AddReservationsForDay(DateTime date, IList<Reservation> reservations);

  Planner GetVacationPlanner();
}

public interface IVacationDayBuilder
{
  void AddReservation(Reservation reservation);
}

public class VacationDayBuilder : IVacationDayBuilder
{
  public IList<Reservation> Reservations { get; private set; }
  public DateTime Date { get; private set; }

  public VacationDayBuilder()
  {
    this.Reservations = new List<Reservation>();
  }

  public void SetDate(DateTime date)
  {
    this.Date = date;
  }

  public void AddReservation(Reservation reservation)
  {
    this.Reservations.Add(reservation);
  }

  public VacationDay GetVacationDay()
  {
    return new VacationDay(this.Date, this.Reservations);
  }
}

public class Planner
{
  public IList<VacationDay> VacationDays { get; private set; }

  public Planner(IList<VacationDay> vacationDays)
  {
    this.VacationDays = vacationDays;
  }
}
