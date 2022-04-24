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
- A diagram detailing the pattern structure
- A "Working example" section, explaining the actual code implemented to exercise the pattern

At the .NET solution you will find:

- A `ProjectName.Domain` class library project, containing the classes and the domain logic
- A `ProjectName.DomainTests` xunit project, containing the tests for the domain classes
- A `ProjectName.ConsoleApp` console project, containing an executable for the working example

## Language choice

I chose to use C# (on top of .NET Core) as the programming language to implement these patterns, as it is a traditional, strongly-typed Object-Oriented language.

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

**Creational patterns**

Creational design patterns abstract the instantiation process. They help make a system independent of how its objects are created, composed and represented.

The creational design patterns presented at GoF's book are:

- [Abstract Factory](/abstract-factory)
- [Builder](/builder)
- [Factory Method](/factory-method)
- [Prototype](/prototype)
- [Singleton](/singleton)

**Structural patterns**

Structural patterns are concerned with how classes and objects are composed to form larger structures.

The structural design patterns presented at GoF's book are:

- [Composite](/composite)
- [Decorator](/decorator)
- [Adapter](/adapter)
- [Facade](/facade)

**Behavioral patterns**

Behavioral patterns are concerned with algorithms and the assignment of responsibilities between objects. Behavioral patterns describe not just patterns of objects or classes but also the patterns of communication between them. These patterns characterize complex flow that's difficult to follow at run-time. They shift your focus away from flow of control to let you concentrate just on the way objects are interconnected.

The behavioral design patterns presented at GoF's book are:

- [Strategy](/strategy)
- [Observer](/observer)
- [Command](/command)
- [Template method](/template-method)
- [Iterator](/iterator)
- [State](/state)
