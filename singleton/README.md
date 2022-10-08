# Singleton Pattern

The Singleton Pattern ensures a class has only one instance, and provides a global point of access to it.

## Considerations

Although the Singleton Pattern is really straightforward to implement, it has many implications on the design of a system. For instance, in multithreaded applications you might have problems synchronizing access to the singleton instance and making sure that there's only one instance of the class. Language constructs like (`synchronized` (Java) and `volatile` (C#)) might help here, with some impact on performance. Testing is also a big concern, as it's not easy to test the behavior of a singleton, specially when you want to put it in a specific state before running the test against it (that's why I made the constructor protected and subclassed it in the working example).

## How-To

```csharp
  public static class Singleton
  {
    private static Singleton uniqueInstance;

    // constructor is made private so no code outside of this class is allowed to instantiate it
    private Singleton() { }

    public Singleton GetInstance()
    {
      if (uniqueInstance == null)
      {
        uniqueInstance = new Singleton();
      }

      return uniqueIsntance;
    }
  }
```

## Working example

The working example for this pattern was inspired by the `ChocolateBoiler` project described in the Head-First Design Patterns book. The `ChocolateBoiler` class is responsible for boiling chocolate + milk in a chocolate factory. This factory only has one boiler, that's why we needed it to be a singleton in the code. Make sure to check out the [ChocOHolic](./ChocOHolic/) project for the implementation details.
