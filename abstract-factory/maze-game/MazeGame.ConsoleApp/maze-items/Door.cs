namespace MazeGame.MazeItems;

public class Door : MapSite
{
  public override void Enter()
  {
    throw new NotImplementedException();
  }

  public virtual string GetIcon()
  {
    return "🚪";
  }
}
