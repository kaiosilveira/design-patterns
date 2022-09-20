using Patternsland.Domain.Vacations;
using Patternsland.Domain.Vacations.Builders;

namespace Patternsland.Domain;

public class Client
{
  private readonly IVacationBuilder vacationBuilder;

  public Client(IVacationBuilder vacationBuilder)
  {
    this.vacationBuilder = vacationBuilder;
  }

  VacationPlanner ConstructPlanner()
  {
    return this.vacationBuilder.GetVacationPlanner();
  }
}
