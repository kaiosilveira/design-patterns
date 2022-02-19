using AbstractFactoryPattern.Enumerators;

namespace AbstractFactoryPattern.MazeItems.Bombed;

public class BombedWall : Wall
{
  public BombedWall(Orientation orientation) : base(orientation) { }

  public override string GetDoorIcon() => this._door != null ? this._door.GetIcon() : "";

  public override string GetIcon() => "💣";
}