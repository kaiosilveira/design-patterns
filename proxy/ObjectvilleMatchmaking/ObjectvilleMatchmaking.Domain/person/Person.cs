namespace ObjectvilleMatchmaking.Domain.Entities;

public interface Person
{
  public int GetHotOrNotRating();
  public void SetHotOrNotRating(int rating);
  public string GetName();
  public void SetName(string name);
  public string GetInterests();
  public void SetInterests(string interests);
  public Gender GetGender();
  public void SetGender(Gender gender);
}
