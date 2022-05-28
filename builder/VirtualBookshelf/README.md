# Virtual Bookshelf

This is a simple project to demonstrate the usage of a fluent builder. In this example, we're going to build a book part by part, using a builder, and we are going to retrieve the final product by calling `builder.Build()`.

## Sequence diagram

```mermaid
sequenceDiagram

Client ->>+ BookBuilder: new
Note right of BookBuilder: Creates a BookBuilder instance
BookBuilder ->>- Client : self

Client ->>+ BookBuilder: From(author)
Note right of BookBuilder: Adds author to the book and returns itself
BookBuilder ->>- Client : self

Client ->>+ BookBuilder: By(publisher)
Note right of BookBuilder: Adds publisher to the book and returns itself
BookBuilder ->>- Client : self

Client ->>+ BookBuilder: WithTitle(title)
Note right of BookBuilder: Adds title to the book and returns itself
BookBuilder ->>- Client : self

Client ->>+ BookBuilder: WithISBN(isbn)
Note right of BookBuilder: Adds ISBN to the book and returns itself
BookBuilder ->>- Client : self

Client ->>+ BookBuilder: WithPrice(price)
Note right of BookBuilder: Adds price to the book and returns itself
BookBuilder ->>- Client : self

Client ->>+ BookBuilder: Build()
Note right of BookBuilder: Returns the resulting book object instance
BookBuilder ->>- Client : book
```
