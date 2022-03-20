namespace MazeGame.MazeItems.Bombed;

public class BombedDoor : Door
{
  public BombedDoor() : base() { }

  public override void Enter() => throw new NotImplementedException();

  public override string GetIcon() => "🪟";
}