using Xunit;
using DuckAdapter.Animals;
using DuckAdapter.Animals.Adapters;

namespace DuckAdapter.Tests;

public class TurkeyAdapterTest
{
  [Fact]
  public void TestAdaptsATurkey()
  {
    var adapter = new TurkeyAdapter(new WildTurkey());
    Assert.IsAssignableFrom<Duck>(adapter);
  }
}