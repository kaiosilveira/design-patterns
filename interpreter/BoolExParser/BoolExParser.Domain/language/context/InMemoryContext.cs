namespace BoolExParser.Domain.Language.Contexts;

public class InMemoryLanguageContext : Context
{
  private Dictionary<char, bool> lookupTable;

  public InMemoryLanguageContext()
  {
    this.lookupTable = new Dictionary<char, bool>();
  }

  public void Assign(char exp, bool value)
  {
    this.lookupTable.Add(exp, value);
  }

  public bool Lookup(char variableName)
  {
    return this.lookupTable.GetValueOrDefault(variableName, defaultValue: false);
  }
}