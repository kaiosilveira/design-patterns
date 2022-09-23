namespace LandscapeDesign.ConsoleApp;

public class Program
{
  public static void Main(string[] args)
  {
    var appState = new ConfigView().Render();
    while (appState.LastCommand != "q")
    {
      Console.Clear();

      if (appState.CurrentView == TerminalViews.CONFIG)
        appState = new ConfigView().Render();
      if (appState.CurrentView == TerminalViews.EDIT_ITEM)
        appState = new EditItemView(appState).Render();
      if (appState.CurrentView == TerminalViews.INTERACTIVE)
        appState = new InteractiveView(appState).Render();
    }
  }
}