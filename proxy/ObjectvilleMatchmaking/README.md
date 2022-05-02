# Objectville Matchmaking

This is a matchmaking application to demonstrate the implementation of the Protection Proxy Pattern. This app has a `Person` interface, which contains some methods to handle the person's data, such as the name and the interests. The protection needs to be implemented for the setters to prevent one of changing somebody else's name, interests and gender, for instance. At the same time, an user is not allowed to change his/her
own rating, which is the result of the moving average of all ratings up to now.

The `PersonImpl` is the class created to implement the `Person` interface and represent a person in the system. It's implementation is simple and straightforward:

```csharp
public class PersonImpl : Person
{
  // private variables declared here, and the Id has a public getter:
  public string Id { get; private set; }

  public PersonImpl(
    string id, string name = "Unknown", string interests = "Unknown",
    int hotOrNotRating = 0, Gender gender = Gender.OTHER)
  {
    // code to assign the arguments to the instance variables goes here
  }

  public Gender GetGender() => this._gender;

  public void SetGender(Gender gender) => this._gender = gender;

  public string GetInterests() => this._interests;

  public void SetInterests(string interests) => this._interests = interests;

  public string GetName() => this._name;

  public void SetName(string name) => this._name = name;

  public int GetHotOrNotRating() => this._hotOrNotRating;

  public void SetHotOrNotRating(int rating)
  {
    this._ratingCount++;
    this._hotOrNotRating = (this._hotOrNotRating + rating) / this._ratingCount;
  }
}
```

To implement the protection described above, a `PersonProxy` was introduced. This proxy receives the information needed to perform validations at instantiation time. To keep things simple, a `callerId` and `person.Id` were used to validate identity. The `PersonProxy` looks like this:

```csharp
public class PersonProxy : Person
{
  private bool _isOwner;
  private PersonImpl _person;

  public PersonProxy(string callerId, PersonImpl person)
  {
    this._person = person;
    this._isOwner = callerId == person.Id;
  }

  public Gender GetGender() => this._person.GetGender();

  public int GetHotOrNotRating() => this._person.GetHotOrNotRating();

  public string GetInterests() => this._person.GetInterests();

  public string GetName() => this._person.GetName();

  public void SetHotOrNotRating(int rating) => this.ProtectedInvocation(
    !this._isOwner, () => this._person.SetHotOrNotRating(rating));

  public void SetGender(Gender gender) => this.ProtectedInvocation(
    this._isOwner, () => this._person.SetGender(gender));

  public void SetInterests(string interests) => this.ProtectedInvocation(
    this._isOwner, () => this._person.SetInterests(interests));

  public void SetName(string name) => this.ProtectedInvocation(
    this._isOwner, () => this._person.SetName(name));

  private void ProtectedInvocation(bool conditionSatisfied, Action fn)
  {
    if (conditionSatisfied) fn();
    else throw new IllegalInvocationException();
  }
}
```

At runtime, we can pass an instance of the proxy to the clients instead of handing over the actual `PersonImpl` class. We can even use an [Abstract Factory](../../abstract-factory/) to enforce this rule.
