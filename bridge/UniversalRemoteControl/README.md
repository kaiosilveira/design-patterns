# Universal remote control

This project focuses on exposing a universal interface for a remote control. It detaches the abstraction of the remote control of its many implementations, allowing them to vary independently.

## Class diagram

```mermaid
classDiagram

class TV {
    On()
    Off()
    TuneChannel()
}

class RemoteControl {
    TV implementor
    On()
    Off()
    SetChannel()
}

class SonyTV {
    bool IsOn
    On()
    Off()
    TuneChannel()
}

class SamsungTV {
    bool IsOn
    On()
    Off()
    TuneChannel()
}

class SonyRemote {
    On()
    Off()
    SetChannel()
}

class SamsungRemote {
    On()
    Off()
    SetChannel()
}

TV <|-- SonyTV : implements
TV <|-- SamsungTV : implements
RemoteControl <|-- SonyRemote : implements
RemoteControl <|-- SamsungRemote : implements
TV <-- RemoteControl : has-a
```
