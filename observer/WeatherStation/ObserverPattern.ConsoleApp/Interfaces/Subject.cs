namespace ObserverPattern.Observable;

public interface Subject<T>
{
  void Attach(Observer<T> o);
  void Detach(Observer<T> o);
  void Notify();
}
