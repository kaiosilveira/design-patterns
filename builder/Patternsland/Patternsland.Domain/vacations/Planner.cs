namespace Patternsland.Domain.Vacations;

public class VacationPlanner
{
  public IList<VacationDay> VacationDays { get; private set; }

  public VacationPlanner(IList<VacationDay> vacationDays)
  {
    this.VacationDays = vacationDays;
  }
}
