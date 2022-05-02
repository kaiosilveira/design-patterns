using Xunit;
using ObjectvilleMatchmaking.Domain.Entities;
using ObjectvilleMatchmaking.Domain.Exceptions;

namespace ObjectvilleMatchmaking.DomainTests;

public class PersonProxyTest
{
  [Fact]
  public void TestAllowsAccessToGetters()
  {
    var person = new PersonImpl(
      id: "person-id", name: "John Doe", interests: "Programming, games",
      hotOrNotRating: 7, gender: Gender.MALE
    );

    var proxy = new PersonProxy(callerId: person.Id, person);

    Assert.Equal("John Doe", person.GetName());
    Assert.Equal("Programming, games", person.GetInterests());
    Assert.Equal(7, person.GetHotOrNotRating());
    Assert.Equal(Gender.MALE, person.GetGender());
  }

  [Fact]
  public void TestAllowsChangingOwnInterests()
  {
    var person = new PersonImpl(id: "person-id");
    var proxy = new PersonProxy(callerId: "person-id", person);

    proxy.SetInterests("Programming, games");

    Assert.Equal("Programming, games", proxy.GetInterests());
  }

  [Fact]
  public void TestDoesNotAllowChangingSomebodyElsesInterests()
  {
    var person = new PersonImpl(id: "person-id");
    var proxy = new PersonProxy(callerId: "another-person-id", person);

    Assert.Throws<IllegalInvocationException>(() => proxy.SetInterests("Programming, games"));
  }

  [Fact]
  public void TestAllowChangingSomebodyElsesRating()
  {
    var person = new PersonImpl(id: "person-id");
    var proxy = new PersonProxy(callerId: "another-person-id", person);

    proxy.SetHotOrNotRating(10);

    Assert.Equal(10, proxy.GetHotOrNotRating());
  }

  [Fact]
  public void TestDoesNotAllowChangingOwnRating()
  {
    var person = new PersonImpl(id: "person-id");
    var proxy = new PersonProxy(callerId: "person-id", person);

    Assert.Throws<IllegalInvocationException>(() => { proxy.SetHotOrNotRating(10); });
  }

  [Fact]
  public void TestDoesNotAllowChangingSomebodyElsesGender()
  {
    var person = new PersonImpl(id: "person-id");
    var proxy = new PersonProxy(callerId: "another-person-id", person);

    Assert.Throws<IllegalInvocationException>(() => proxy.SetGender(Gender.FEMALE));
  }

  [Fact]
  public void TestDoesNotAllowChangingSomebodyElsesName()
  {
    var person = new PersonImpl(id: "person-id");
    var proxy = new PersonProxy(callerId: "another-person-id", person);

    Assert.Throws<IllegalInvocationException>(() => proxy.SetName("Jane Doe"));
  }
}