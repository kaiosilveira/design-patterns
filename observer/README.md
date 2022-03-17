# Observer pattern

Define a one to many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

## How-to

The implementation itself may vary depending on how much data we want to share between the two parts, but the top-level idea remains the same:

- We start by defining two interfaces, one for the `Subject` and one for the `Observers`:

```csharp
interface Subject
{
  void Attach(Observer o);
  void Detach(Observer o);
  void Notify();
}

interface Observer
{
  void Update(State s);
}
```

- We can then build concrete classes implementing these interfaces accordingly. First, the `Subject`:

```csharp
class ConcreteSubject : Subject
{
  private SubjectState state { get; set; };
  private List<Observer> observers { get; set; }

  public ConcreteSubject()
  {
    this.observers = [];
  }

  public void Attach(Observer o)
  {
    this.observers.Add(o);
  }

  public void Detach(Observer o)
  {
    this.observers.Remove(o);
  }

  public void Notify()
  {
    this.observers.ForEach(o => o.Update(this.state));
  }
}
```

- Then, the `Observer`'s:

```csharp
class ConcreteObserver : Observer
{
  public ConcreteObserver()
  {}

  public void Update(State s)
  {
    // updates internal state accordingly
  }
}
```

GoF's book also describes a more complex way of handling state changes, should the state be too complicated to be handled by being passed down directory to `Observer`'s, we could add a `ChangeManager` (using the Mediator Pattern) to abstract away the complex parts, therefore making the communication more streamlined.

## Working example

For our working example we are going to implement a weather application.
