namespace PrototypePattern.Documents;

public abstract class Document
{
  public abstract string Copy(int start, int length);
  public abstract void Paste(string content, int position);
  public abstract string GetContents();
}
