using ObjectvilleFood.Domain.MenuDefinition;

namespace ObjectvilleFood.Domain.Visitors;

public interface Visitor
{
  void VisitMenuItem(MenuItem item);
  void VisitMenu(Menu menu);
}
