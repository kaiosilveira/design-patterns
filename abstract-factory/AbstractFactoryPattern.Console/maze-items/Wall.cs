using AbstractFactoryPattern.Enumerators;

namespace AbstractFactoryPattern.MazeItems
{
  public class Wall : MapSite
  {
    protected Door? _door;
    protected readonly Orientation _orientation;

    public Wall(Orientation orientation) => this._orientation = orientation;

    public virtual bool HasDoor => this._door != null;

    public virtual void AddDoor(Door door) => this._door = door;

    public virtual string GetDoorIcon() => this._door != null ? this._door.GetIcon() : "";

    public virtual string GetIcon() => this._orientation == Orientation.VERTICAL ? "|" : "--";

    public override void Enter() => throw new System.NotImplementedException();
  }
}
