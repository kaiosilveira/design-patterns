namespace HomeAutomationInc.Commands;

public interface Command
{
  void Execute();

  void Undo();

  string GetName();
}
