namespace ObserverPattern.Observable;

public interface Observer<T>
{
  void Update(T state);
}