namespace MazeGame.MazeItems.Enchanted;

public class EnchantedDoor : Door
{
  public EnchantedDoor() : base() { }

  public override void Enter() => throw new NotImplementedException();

  public override string GetIcon() => "🪞";
}