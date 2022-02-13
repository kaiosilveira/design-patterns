namespace CompositePattern.Console
{
  public class Word : Renderable
  {
    public string Value { get; }

    public Word(string value = "")
    {
      this.Value = value;
    }

    public string Render()
    {
      return this.Value;
    }

    public void Add(Renderable letter)
    {
      throw new NotImplementedException();
    }
  }
}