namespace CompositePattern.Console
{
  public class Paragraph : Renderable
  {
    public List<Renderable> Words { get; }
    public Paragraph()
    {
      this.Words = new List<Renderable>();
    }

    public string Render()
    {
      var result = "";

      this.Words.ForEach(word =>
      {
        result += word.Render();
      });

      return result;
    }

    public void Add(Renderable word)
    {
      this.Words.Add(word);
    }
  }
}