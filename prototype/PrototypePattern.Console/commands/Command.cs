namespace PrototypePattern.Commands;
public abstract class Command<TTarget> : Cloneable<TTarget>
{
  public abstract void Execute();
  public abstract Cloneable<TTarget> Clone();
}