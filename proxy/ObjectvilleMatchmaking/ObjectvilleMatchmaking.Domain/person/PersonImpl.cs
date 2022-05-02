namespace ObjectvilleMatchmaking.Domain.Entities;

public class PersonImpl : Person
{
  private Gender _gender;
  private string _name;
  private string _interests;
  private int _hotOrNotRating;
  private int _ratingCount;
  public string Id { get; private set; }

  public PersonImpl(
    string id, string name = "Unknown", string interests = "Unknown",
    int hotOrNotRating = 0, Gender gender = Gender.OTHER)
  {
    this.Id = id;
    this._name = name;
    this._interests = interests;
    this._hotOrNotRating = hotOrNotRating;
    this._gender = gender;
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