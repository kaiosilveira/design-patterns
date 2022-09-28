# Visitor

Represents an operation to be performed on the elements of an object structure. Visitor lets you define a new operation without changing the classes of elements on which it operates.

## Structure

The formal structure for the visitor pattern has many moving parts. The class diagram below shows how these parts interact with each other:

```mermaid
classDiagram

class Client
class ObjectStructure

class Visitor {
    VisitConcreteElementA(ConcreteElementA el)
    VisitConcreteElementB(ConcreteElementB el)
}

class ConcreteVisitor1 {
    VisitConcreteElementA(ConcreteElementA el)
    VisitConcreteElementB(ConcreteElementB el)
}

class ConcreteVisitor2 {
    VisitConcreteElementA(ConcreteElementA el)
    VisitConcreteElementB(ConcreteElementB el)
}

class Element {
    Accept(Visitor v)
}

class ConcreteElementA {
    Accept(Visitor v)
    OperationA()
}

class ConcreteElementB {
    Accept(Visitor v)
    OperationB()
}

Client --> Visitor : uses-a
Client --> ObjectStructure : interacts-with-a

ObjectStructure --> Element : has-many

Element <|-- ConcreteElementA : implements
Element <|-- ConcreteElementB : implements

Visitor <|-- ConcreteVisitor1 : implements
Visitor <|-- ConcreteVisitor2 : implements
```

Considering the structure above, a `Client` usually acts as a `Traverser` over a given `ObjectStructure`, providing one or more `Visitor` instances to it. Each `ConcreteElement` implements a method to `Accept` a visitor and calls `VisitConcreteElementX` on the `Visitor`, hinting at the concrete element's class. Then the visitor, knowing from which concrete class it was invoked, executes the operation it wants on the concrete class. The sequence diagram below helps understanding this flow:

```mermaid
sequenceDiagram
participant anObjectStructure
participant aConcreteElementA
participant aConcreteElementB
participant aConcreteVisitor

activate anObjectStructure

anObjectStructure ->> aConcreteElementA : Accept(aVisitor)
activate aConcreteElementA
aConcreteElementA ->>  aConcreteVisitor: VisitConcreteElementA(aConcreteElementA)
deactivate aConcreteElementA

activate aConcreteVisitor
aConcreteVisitor ->> aConcreteElementA : OperationA()
deactivate aConcreteVisitor

activate aConcreteElementA
deactivate aConcreteElementA

anObjectStructure ->> aConcreteElementB : Accept(aVisitor)
activate aConcreteElementB
aConcreteElementB ->>  aConcreteVisitor: VisitConcreteElementB(aConcreteElementB)
deactivate aConcreteElementB

activate aConcreteVisitor
aConcreteVisitor ->> aConcreteElementB : OperationB()
deactivate aConcreteVisitor

activate aConcreteElementB
deactivate aConcreteElementB
deactivate anObjectStructure
```

Visitors are useful when we want to extend the behavior of a class hierarchy without "polluting" the related classes with more code. It's specially helpful when working with composites.

## Working example

The working example for this pattern is built on top of what we've done for the [Composite Pattern](../composite), where we had a composite structure formed by `MenuComponent` subclasses. Here we've implemented a `Visitor` class hierarchy, containing two visitors: `HealthInformationVisitor` and `MacroNutrientsVisitor`, these two, as the name suggests, are responsible for gathering information regarding health score and macro nutrients info for all menu items. Check out [ObjectvilleFood](./ObjectvilleFood/) for implementation details and further explanations.
