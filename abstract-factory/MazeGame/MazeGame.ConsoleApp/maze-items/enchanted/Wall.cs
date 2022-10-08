using MazeGame.Enumerators;

namespace MazeGame.MazeItems.Enchanted;

public class EnchantedWall : Wall
{
  public EnchantedWall(Orientation orientation) : base(orientation) { }

  public override string GetDoorIcon() => this._door != null ? this._door.GetIcon() : "";

  public override string GetIcon() => "✨";
}