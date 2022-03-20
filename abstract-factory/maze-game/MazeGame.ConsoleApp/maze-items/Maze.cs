using MazeGame.Interfaces;

namespace MazeGame.MazeItems;

public class Maze : Drawable
{
  private readonly List<Room> _rooms;

  public Maze() => this._rooms = new List<Room>();

  public virtual void AddRoom(Room room) => this._rooms.Add(room);

  public virtual void Draw() => this._rooms.ForEach(room => room.Draw());

  public virtual Room RoomNo(int index) => this._rooms.ToArray()[index];
}
