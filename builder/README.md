# Builder Pattern

The builder pattern provides a way to abstract away the complexities of instantiating objects, allowing classes to change independently and in a more flexible fashion without impacting many clients.

**Book definition:** Separate the construction of a complex object from its representation so that the same construction process can create different representations.

## How-To

A builder is commonly a class that's specialist in creating a particular kind of object, so we commonly have the following group of classes working together:

```csharp
class Part {
  public Part() {}
}

class Product {
  public Product() {}

  public void AddPart(Part part)
  {
    this._part = part;
  }
}

class ProductBuilder {
  public ProductBuilder()
  {
    this._currentProduct = new Product();
  }

  public void buildPart()
  {
    this._currentProduct.AddPart(new Part());
  }

  public Product getProduct()
  {
    return this._currentProduct;
  }
}
```

## Working example

As our working example, we're going to implement a book builder in a slightly different fashion: Our builder is going to be a Fluent Builder. There main different between a regular builder and a fluent one is that it keeps returning itself until the `Build()` method is called, this allow for method chaining in a graceful way while keeping all the part-building approach working as in the regular ones.

Our book is going to have the following fields:

- ISBN
- Title
- Author
- Distributor
- Price

And the result would look like this:

```csharp
    var result = new BookBuilder()
      .From(author)
      .By(publisher)
      .WithTitle(title)
      .WithISBN(isbn)
      .WithPrice(price)
      .Build();
```
