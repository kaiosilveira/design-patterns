[![CI](https://github.com/kaiosilveira/design-patterns/actions/workflows/dotnet.yml/badge.svg)](https://github.com/kaiosilveira/design-patterns/actions/workflows/dotnet.yml)

# Design Patterns

This repository was created to exercise my learnings from the Design Patterns book.
As I'm not exactly creative, at the beginning I found it hard to come up with real-world examples to implement, but thankfully the Head-First Design-Patterns book helped me with that. It also helped me to better fixate the patterns on my brain. So I'm reading both in parallel. For this reason, new patterns might come up in the order presented at Head-First Design Patterns book instead of the original Design Patterns book, as I'm using it as the main learning source and referring to the GoF book catalog as patterns emerge in the learning path.

## Repository structure

This repository is organizing with subdirectories for each pattern present in the book. Each subdirectory contains:

- A console application package implementing the pattern
- A test package implementing the corresponding tests

At the `README.md` file of each pattern, you will find:

- An overall view of the pattern
- A "How-To" section, giving a top-level view of the structure
- A "Working example" section, explaining the actual code implemented to exercise the pattern

## Language choice

I decided to use C# (on top of .NET Core) as the programming language choice to implement the patterns, as it is a traditional, strongly-typed Object-Oriented language.

## OO Principles
These are the OO principles highlighted by the books:
- Encapsulate what varies
- Favor composition over inheritance
- Program to interfaces, not implementations
- Strive for loosely coupled designs between objects that interact
- Classes should be open for extension and closed for modification
- Depend on abstractions. Do not depend on concretions
- Talk only to your friends

## Pattern catalog

**Creational patterns**

- [Abstract Factory](/abstract-factory)
- [Builder](/builder)
- [Factory Method](/factory-method)
- [Prototype](/prototype)
- [Singleton](/singleton)

**Structural patterns**

- [Composite](/composite)
- [Decorator](/decorator)
- [Adapter](/adapter)
- [Facade](/facade)

**Behavioral patterns**

- [Strategy](/strategy)
- [Observer](/observer)
- [Command](/command)
