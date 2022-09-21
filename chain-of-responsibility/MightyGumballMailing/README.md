🚧 **This repository is a work in progress and is being constantly updated. Stay tuned and don't mind the mess!** 🚧

# MightyGumballMailing

MightyGumballMailing is a hypothetical system responsible for handling incoming emails towards the MightyGubmall organization, its main purpose is to check the email type and perform appropriate actions according to each type. For simplicity and completeness, let's imagine that there's an existing AI system categorizing the emails by type before feeding them into `MightyGumballMailing`.

- Handler classes are structured as follows:

```mermaid
classDiagram

class MailHandler {
    Handler successor
    HandleIncomingEmail()
}

class SpamMailHandler {
    HandleIncomingEmail()
}

class FanMailHandler {
    HandleIncomingEmail()
}

class ComplaintMailHandler {
    HandleIncomingEmail()
}

class DefaultMailHandler {
    HandleIncomingEmail()
}

MailHandler <|-- SpamMailHandler : implements
MailHandler <|-- FanMailHandler : implements
MailHandler <|-- ComplaintMailHandler : implements
MailHandler <|-- DefaultMailHandler : implements
```

- The sequence diagram below shows how a client interacts with the mail handling responsibility chain:

```mermaid
sequenceDiagram
    participant client
    participant spamMailHandler
    participant fanMailHandler
    participant complaintMailHandler
    participant defaultMailHandler
    activate client

    client->>spamMailHandler: HandleIncomingEmail()
    activate spamMailHandler
    spamMailHandler-->>fanMailHandler: HandleIncomingEmail()
    deactivate spamMailHandler
    activate fanMailHandler
    fanMailHandler-->>complaintMailHandler: HandleIncomingEmail()
    deactivate fanMailHandler
    activate complaintMailHandler
    complaintMailHandler-->>defaultMailHandler: HandleIncomingEmail()
    deactivate complaintMailHandler
    activate defaultMailHandler
    deactivate defaultMailHandler
    deactivate client
```
