namespace PrototypePattern.Documents;
public class TextDocument : Document
{
  private string _contents { get; set; }
  public TextDocument(string contents)
  {
    this._contents = contents;
  }

  public override string Copy(int start, int length)
  {
    return this._contents.Substring(start, length);
  }

  public override void Paste(string content, int position)
  {
    var remainder = this._contents.Substring(position, this._contents.Length - position);
    this._contents = String.Concat(this._contents.Substring(0, position), content, remainder);
  }

  public override string GetContents()
  {
    return this._contents;
  }
}
