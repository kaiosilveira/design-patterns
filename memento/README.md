# Memento

Without violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.

## Structure

```mermaid
classDiagram

class Originator {
    state
    SetMemento(Memento m)
    CreateMemento()
}

class Memento {
    state
    GetState()
    SetState()
}

class CareTaker

Originator --> Memento : manipulates-a
CareTaker --> Memento : holds-a-reference-of
```

```mermaid
sequenceDiagram

activate aCareTaker
aCareTaker ->> anOriginator: CreateMemento()
activate anOriginator
anOriginator -->> aMemento: new Memento()
activate aMemento
deactivate aMemento
anOriginator ->> aMemento: SetState()
activate aMemento
deactivate aMemento
deactivate anOriginator
deactivate aCareTaker
```
