using HouseOfTheFuture.Domain.Widgets;

public class MainView
{
  private readonly ApplicationState appState;

  public MainView(ApplicationState appState)
  {
    this.appState = appState;
  }

  public ApplicationState Render(Clock clock, Display display)
  {
    display.Render();
    return new ApplicationState(appState.CurrentView, appState.LastCommand);
  }
}
