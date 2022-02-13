using PrototypePattern.Documents;
namespace PrototypePattern.Commands;

public class PasteCommand : Command<TextDocument>
{
  private readonly TextDocument _target;
  private readonly int _pastePosition;
  private readonly string _contentToPaste;

  public PasteCommand(TextDocument target, string contentToPaste, int pastePosition)
  {
    this._target = target;
    this._contentToPaste = contentToPaste;
    this._pastePosition = pastePosition;
  }
  public override PasteCommand Clone()
  {
    return new PasteCommand(this._target, this._contentToPaste, this._pastePosition);
  }

  public override void Execute()
  {
    this._target.Paste(this._contentToPaste, this._pastePosition);
  }
}
