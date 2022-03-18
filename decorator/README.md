# Decorator Pattern

The decorator pattern allow us to compose objects while keeping the same top-level interface, thus allowing for enhancing the behavior of the target objects in a flexible and run-timleable way.

```
Book definition: The Decorator Pattern attaches additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
```

## Structure

```mermaid
classDiagram
class Component{
    methodA();
    methodB();
}

class ConcreteComponent{
    methodA();
    methodB();
}

class Decorator{
    Component wrappedObj
    methodA();
    methodB();
}

class ConcreteDecoratorA{
    Component wrappedObj
    methodA();
    methodB();
}

class ConcreteDecoratorB{
    Component wrappedObj
    methodA();
    methodB();
}

Component<|--ConcreteComponent
Component<|--Decorator
Decorator<|--ConcreteDecoratorA
Decorator<|--ConcreteDecoratorB
```

## How-to

## Working example
