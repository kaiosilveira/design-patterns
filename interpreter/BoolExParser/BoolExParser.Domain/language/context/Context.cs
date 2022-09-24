namespace BoolExParser.Domain;

public interface Context
{
  public bool Lookup(char variableName);
  public void Assign(char exp, bool value);
}
