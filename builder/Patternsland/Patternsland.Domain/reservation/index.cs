namespace Patternsland.Domain;

public class Client
{
  private readonly IVacationBuilder vacationBuilder;

  public Client(IVacationBuilder vacationBuilder)
  {
    this.vacationBuilder = vacationBuilder;
  }

  Planner ConstructPlanner()
  {
    return this.vacationBuilder.GetVacationPlanner();
  }
}
