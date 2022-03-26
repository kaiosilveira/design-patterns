
namespace HomeAutomationInc.Commands;

public class NoCommand : Command
{
  public void Execute() { }

  public string GetName()
  {
    return "NoCommand";
  }

  public void Undo()
  {
    throw new NotImplementedException();
  }
}
