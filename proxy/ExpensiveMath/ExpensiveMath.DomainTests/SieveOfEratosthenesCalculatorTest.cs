using System.Collections.Generic;
using ExpensiveMath.Algorithms;
using Xunit;

namespace ExpensiveMath.DomainTests;

public class TestingSieveOfEratosthenesCalculator : SieveOfEratosthenesCalculator
{
  public List<int> FetchPrimesUpTo(int n)
  {
    return this.GetPrimesUpTo(n);
  }
}

public class SieveOfEratosthenesCalculatorTest
{
  [Fact]
  public void TestCalculatesCorrectly()
  {
    var calculator = new TestingSieveOfEratosthenesCalculator();
    var result = calculator.FetchPrimesUpTo(n: 13);

    Assert.Equal(new List<int> { 2, 3, 5, 7, 11, 13 }, result);
  }
}