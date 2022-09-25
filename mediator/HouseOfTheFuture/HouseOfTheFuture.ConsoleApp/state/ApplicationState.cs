public class ApplicationState
{
  public readonly string LastCommand;
  public readonly ViewTypes CurrentView;

  public ApplicationState(ViewTypes currentView, string lastCommand)
  {
    this.LastCommand = lastCommand;
    this.CurrentView = currentView;
  }
}
