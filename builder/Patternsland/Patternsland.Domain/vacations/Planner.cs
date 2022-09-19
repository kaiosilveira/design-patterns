namespace Patternsland.Domain;

public class Planner
{
  public IList<VacationDay> VacationDays { get; private set; }

  public Planner(IList<VacationDay> vacationDays)
  {
    this.VacationDays = vacationDays;
  }
}
