using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleFood.Domain.Visitors;

public class HealthScoreInfo
{
  public string MenuItemName { get; private set; }
  public string Score { get; private set; }

  public HealthScoreInfo(string menuItemName, string score)
  {
    this.MenuItemName = menuItemName;
    this.Score = score;
  }
}

public class HealthScoreVisitor : Visitor
{
  private List<HealthScoreInfo> HealthScoreInformationList;

  public HealthScoreVisitor()
  {
    this.HealthScoreInformationList = new List<HealthScoreInfo>();
  }

  public void VisitMenuItem(MenuItem item)
  {
    this.HealthScoreInformationList.Add(new HealthScoreInfo(item.Name, item.HealthScore ?? "?"));
  }

  public List<HealthScoreInfo> GetHealthInfoInfo()
  {
    return this.HealthScoreInformationList;
  }

  public void VisitMenu(Menu menu) { }
}