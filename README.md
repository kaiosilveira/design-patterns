[![Continuous Integration](https://github.com/kaiosilveira/design-patterns/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kaiosilveira/design-patterns/actions/workflows/dotnet.yml)

# Design Patterns

This repository was created to exercise my learnings from the Design Patterns book.
As I'm not exactly creative, at the beginning I found it hard to come up with real-world examples to implement, but thankfully the Head-First Design-Patterns book helped me with that. It also helped me to better fixate the patterns on my brain. So I'm reading both in parallel. For this reason, new patterns might come up in the order presented at Head-First Design Patterns book instead of the original Design Patterns book, as I'm using it as the main learning source and referring to the GoF book catalog as patterns emerge in the learning path.

## Repository structure

This repository is organized with subdirectories for each pattern presented in the book. Each subdirectory contains:

- A `README.md` file
- At least one .NET solution implementing the pattern with a working example

At the `README.md` file of each pattern, you will find:

- An overall view of the pattern
- A diagram detailing the pattern's structure
- A "Working example" section, explaining the actual code implemented to exercise the pattern

At the .NET solution you will find:

- A `ProjectName.Domain` class library project, containing the classes and the domain logic
- A `ProjectName.DomainTests` xunit project, containing the tests for the domain classes
- A `ProjectName.ConsoleApp` console project, containing an executable that consumes the domain classes of the working example

## Language choice

C# (on top of .NET Core) was the programming language chosen to be used to implement these patterns, as it is a traditional, strongly-typed Object-Oriented language.

## OO Principles

These are the OO principles highlighted by the books:

- Encapsulate what varies
- Favor composition over inheritance
- Program to interfaces, not implementations
- Strive for loosely coupled designs between objects that interact
- Dependency Inversion Principle: Depend on abstractions. Do not depend on concretions
- Principle of Least Knowledge: Talk only to your immediate friends
- Open-Closed Principle: Classes should be open for extension and closed for modification
- Holywood Principle: "Don't call us, we'll call you"
- Single responsibility Principle: A class should have only one reason to change

## Pattern catalog

### Creational patterns

Creational design patterns abstract the instantiation process. They help make a system independent of how its objects are created, composed and represented.

The creational design patterns presented at GoF's book are:

- [Abstract Factory](/abstract-factory): Provides an interface for creating families of related or dependent objects without specifying their concrete classes.

- [Builder](/builder): Separates the construction of a complex object from its representation so that the same construction process can create different representations.

- [Factory Method](/factory-method): Defines an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

- [Prototype](/prototype): Specifies the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

- [Singleton](/singleton): Ensures a class has only one instance, and provides a global point of access to it.

### Structural patterns

Structural patterns are concerned with how classes and objects are composed to form larger structures.

The structural design patterns presented at GoF's book are:

- [Composite](/composite): Composes objects into tree structures to represent part-whole hierarchies. Composite lets clients treat individual objects and compositions of objects uniformly.

- [Decorator](/decorator): Attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.

- [Adapter](/adapter): Converts the interface of a class into another interface the clients expect. Adapter lets class work together that couldn't otherwise because of incompatible interfaces.

- [Facade](/facade): Provides a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.

- [Proxy](/proxy): Provides a surrogate or placeholder for another object to control access to it.

### Behavioral patterns

Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects. Behavioral patterns describe not just patterns of objects or classes but also the patterns of communication between them. These patterns characterize complex flow that's difficult to follow at run-time. They shift your focus away from flow of control to let you concentrate just on the way objects are interconnected.

The behavioral design patterns presented at GoF's book are:

- [Chain of Responsibility](/chain-of-responsibility/): Helps avoid coupling the sender of a request to its receiver by giving more than one object a chance to handle the request. Chain the receiving objects and pass the request along the chain until an object handles it.

- [Strategy](/strategy): Defines a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

- [Observer](/observer): Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

- [Command](/command): Encapsulates a request as an object, thereby letting you parameterize other objects with different requests, queue or log requests, and support undoable operations.

- [Template method](/template-method): Defines the skeleton of an algorithm in a method, deferring some steps to subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.

- [Iterator](/iterator): Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.

- [State](/state): Allows an object to alter its behavior when its internal state changes. The object will appear to change its class.
