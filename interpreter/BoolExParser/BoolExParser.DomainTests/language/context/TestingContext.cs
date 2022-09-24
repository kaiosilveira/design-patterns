using System.Collections.Generic;
using BoolExParser.Domain;

namespace BoolExParser.DomainTests.Language.Contexts;

public class TestingContext : Context
{
  private Dictionary<char, bool> variableDictionary;

  public TestingContext()
  {
    this.variableDictionary = new Dictionary<char, bool>();
  }

  public void Assign(char exp, bool value)
  {
    this.variableDictionary.Add(exp, value);
  }

  public bool Lookup(char variableName)
  {
    return this.variableDictionary.GetValueOrDefault<char, bool>(variableName, false);
  }
}