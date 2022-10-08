namespace MazeGame.MazeItems.Bombed;

public class BombedMaze : Maze
{
  private readonly List<Room> _rooms;

  public BombedMaze() => this._rooms = new List<Room>();

  public override void AddRoom(Room room) => this._rooms.Add(room);

  public override void Draw() => this._rooms.ForEach(room => room.Draw());

  public override Room RoomNo(int index) => this._rooms.ToArray()[index];
}
