using ObjectvilleMatchmaking.Domain.Exceptions;

namespace ObjectvilleMatchmaking.Domain.Entities;

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