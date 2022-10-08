using PrototypePattern.Documents;
namespace PrototypePattern.Commands;

public class CopyCommand : Command<TextDocument>
{
  private readonly TextDocument _target;
  public readonly int _copyLength;
  private readonly int _startAt;
  public string Buffer { get; set; } = "";

  public CopyCommand(TextDocument target, int startAt, int copyLength)
  {
    this._target = target;
    this._copyLength = copyLength;
    this._startAt = startAt;
  }

  public override CopyCommand Clone()
  {
    return new CopyCommand(this._target, this._startAt, this._copyLength);
  }

  public override void Execute()
  {
    this.Buffer = this._target.Copy(this._startAt, this._copyLength);
  }
}
