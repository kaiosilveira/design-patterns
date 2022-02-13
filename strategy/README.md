# Strategy pattern

The strategy pattern provides a way to allow classes to use an algorithm without knowing the implementation details of it.
Each algorithm is encapsulated as a concrete subclass of the `Strategy` abstract class, overriding its `operation` method to match its needs.
As the working example I expanded the `Renderable` interface presented in the "Composite Pattern" project to allow multiple rendering formats. The `FormattingStrategy` interface was introduced to represent the formatting straegies.
Now, the `Renderable.Render` method expects a parameter specifying the formatting strategy to be used to render the text value. Two formatting strategies were created: `PlainTextFormatter` and `HTMLTextFormatter`, both of them inherit from `Formatter`, which has a default implementation.
