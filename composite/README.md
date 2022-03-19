# Composite Pattern

The composite pattern provides a solution for grouping composable objects that share a common operation under a single interface, so we can handle different levels of composition without worrying whether the object in hand is a primitive or a composite. Composite objects generally keep a list of children.

## Structure

Below we can find the class diagram for the pattern:

```mermaid
classDiagram
class Component {
    Operation()
    Add(Component component)
    Remove(Component component)
    GetChild(int index)
}

class Leaf {
    Operation()
}

class Composite {
    Operation()
    Add(Component component)
    Remove(Component component)
    GetChild(int index)
}

class Client {
    Component component
}

Composite --|> Component
Leaf --|> Component
Client --> Component
```

Notice that a `Client` has a `Component`, this component could be either a `Leaf` or a `Composite`, but the client does not really know, as both of those are implementing the same shared `Component` interface.

## How-To

## Working example

As an working example, I created a structure for rendering text, using two text classes: one that represents a single word and one that represents a paragraph. The `Word` class will contain a primitive string as its value, while the `Paragraph` class will contain multiple words as children. Both classes are going to inherit from the same interface: `Renderable`.
