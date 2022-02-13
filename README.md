# Design Patterns

This repository was created to exercise my learnings from the Design Patterns book. The idea is to create a subdirectory for each design pattern present in the book and a working example of the implementation.

## Language choice

I decided to use C# (on top of .NET Core) as the programming language choice to implement the patterns, as it is a traditional, strongly-typed Object-Oriented language.

## Directory and subdirectories structures

The main directory is structured with a subdirectory for each pattern. Each subdirectory contains a `README.md` file explaining the general idea behind the pattern, followed by an explanation and some context on the working example.
Each subdirectory will be a .NET solution with two projects:

- A Console project, to hold the actual classes and a `Program.cs` file with the running working example
- A Test project, to hold the tests related to the working example

## Pattern catalog

- [Composite](composite/README.md)
- [Strategy](strategy/README.md)
- [Prototype](prototype/README.md)
