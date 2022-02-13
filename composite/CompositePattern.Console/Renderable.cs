namespace CompositePattern.Console
{
  public interface Renderable
  {
    string Render();

    void Add(Renderable renderable);
  }
}