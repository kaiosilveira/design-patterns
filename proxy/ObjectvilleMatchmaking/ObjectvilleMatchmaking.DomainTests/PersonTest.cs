using Xunit;
using ObjectvilleMatchmaking.Domain.Entities;

public class PersonTest
{
  [Fact]
  public void TestSetAndGetName()
  {
    var person = new PersonImpl(id: "person-id");
    person.SetName("John");
    Assert.Equal("John", person.GetName());
  }

  [Fact]
  public void TestSetAndGetInterests()
  {
    var person = new PersonImpl(id: "person-id");
    person.SetInterests("Programming, games");
    Assert.Equal("Programming, games", person.GetInterests());
  }

  [Fact]
  public void TestSetAndGetGender()
  {
    var person = new PersonImpl(id: "person-id");
    person.SetGender(Gender.FEMALE);
    Assert.Equal(Gender.FEMALE, person.GetGender());
  }

  [Fact]
  public void TestSetAndGetHotOrNotRating()
  {
    var person = new PersonImpl(id: "person-id");
    person.SetHotOrNotRating(10);
    Assert.Equal(10, person.GetHotOrNotRating());
  }

  [Fact]
  public void TestCalculatesMovingAverageOfHotOrNotRating()
  {
    var person = new PersonImpl(id: "person-id");

    person.SetHotOrNotRating(3);
    person.SetHotOrNotRating(7);

    Assert.Equal(5, person.GetHotOrNotRating());
  }
}