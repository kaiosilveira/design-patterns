# Observer pattern

Define a one to many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

## Structure

```mermaid
classDiagram
class Observer {
    Update()
}

class ConcreteObserver {
    Update()
}

class Subject {
    Attach(Observer o)
    Detach(Observer o)
    Notify()
}

class ConcreteSubject {
    GetState()
    SetState()
}

ConcreteSubject--|>Subject : implements
ConcreteObserver--|>Observer : implements
Subject-->Observer : has-many

```

Notice that a `Subject` can have many `Observer`'s, each `Observer` has a `ConcreteObserver` implementation, that knows how to `Update()` themselves whenever the `Subject` notifies (`Notify()`) them.

## How-To

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

This working example is extract from the Head First Design Patterns book and implements a weather application. This application is attached to an imaginary `WeatherStation` that is able to collect measurements and send them over to a `WeatherData` class, using the `SetMeasurements()` method. The `WeatherData` implements the Observer Pattern and it represents a `Subject`, so it's able to broadcast about its new updates to all the observers. For the observers we implemented `Display`'s. Each display has a different logic to render a final text, but they all share the same interface. Each display class also implements the `Observer` interface to be able to receive the updates from `WeatherData`. I had to use generics in the `Observer` interface definition so we can pass a `State` object, to encapsulate the measurements fields. Make sure to check out the [WeatherStation](./WeatherStation/) project for full implementation details.
