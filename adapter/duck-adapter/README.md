# Adapter Pattern

The adapter pattern provides us with a way to create alternative interface representations of objects to be used in places where another, possibly incompatible interface is expected.

**Book definition:** The Adapter Pattern converts the interface of a class into another interface the clients expect. Adapter lets class work together that couldn't otherwise because of incompatible interfaces.

## Structure

```mermaid
classDiagram

class Client { }
class Target {
    <<interface>>

    request();
}

class Adapter {
    request();
}

class Adaptee {
    specificRequest();
}

Client --> Target : has-a
Adapter --> Target : implements
Adapter --> Adaptee : delegate-to
```

## Working example

As it looks like I'm not creative enough and the authors of Head-First Design Patterns, in this case, were not that creative as well, the working example is pretty simple: We have a `Duck` interface and a `Turkey` interface, and we adapted a `Turkey` object to behave like a `Duck`.
