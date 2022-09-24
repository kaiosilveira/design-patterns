# BoolExParser

BooleanExp ::= VariableExp | Constant | OrExp | AndExp | NotExp | '(' BooleanExp ')'
AndExp ::= BooleanExp 'and' BooleanExp
OrExp ::= BooleanExp 'or' BooleanExp
NotExp ::= 'not' BooleanExp
COnstant ::= 'true' | 'false'
VariableExp ::= 'A' | 'B' | ... | 'X' | 'Y' | 'Z'

```mermaid
classDiagram

class BooleanExp {
    bool Evaluate()
    BooleanExp Copy()
    BooleanExp Replace()
}

class VariableExp {
    string name

    bool Evaluate()
    BooleanExp Copy()
    BooleanExp Replace()
}

class AndExp {
    BooleanExp operand1
    BooleanExp operand2

    bool Evaluate()
    BooleanExp Copy()
    BooleanExp Replace()
}

class OrExp {
    BooleanExp operand1
    BooleanExp operand2

    bool Evaluate()
    BooleanExp Copy()
    BooleanExp Replace()
}

class NotExp {
    BooleanExp exp

    bool Evaluate()
    BooleanExp Copy()
    BooleanExp Replace()
}

class Constant {
    bool value

    bool Evaluate()
    BooleanExp Copy()
    BooleanExp Replace()
}

BooleanExp <|-- VariableExp : implements
BooleanExp <|-- AndExp : implements
BooleanExp <|-- OrExp : implements
BooleanExp <|-- NotExp : implements
BooleanExp <|-- Constant : implements
```
