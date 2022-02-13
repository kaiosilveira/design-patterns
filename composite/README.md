**Composite Pattern**

The composite pattern provides a solution for grouping composable objects that share a common operation under a single interface, so we can handle different levels of composition without worrying whether the object in hand is a primitive or a composite. Composite objects generally keep a list of children.

## Working example

As an working example, I created a structure for rendering text, using two text classes: one that represents a single word and one that represents a paragraph. The `Word` class will contain a primitive string as its value, while the `Paragraph` class will contain multiple words as children. Both classes are going to inherit from the same interface: `Renderable`.
