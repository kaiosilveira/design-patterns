using Xunit;
using ChocoOHolic.Boiler;
using System.Threading;

namespace ChocOHolic.Tests;

class TestingChocolateBoiler : ChocolateBoiler
{
  public static void ResetInstance()
  {
    uniqueInstance = null;
  }
}

public class ChocolateBoilerTest
{
  [Fact]
  public void TestInitialValues()
  {
    TestingChocolateBoiler.ResetInstance();
    var boiler = ChocolateBoiler.GetInstance();
    Assert.True(boiler.Empty);
    Assert.False(boiler.Boiled);
  }

  [Fact]
  public void TestFill()
  {
    TestingChocolateBoiler.ResetInstance();
    var boiler = TestingChocolateBoiler.GetInstance();
    boiler.Fill();
    Assert.False(boiler.Empty);
  }

  [Fact]
  public void TestBoil()
  {
    TestingChocolateBoiler.ResetInstance();
    var boiler = TestingChocolateBoiler.GetInstance();

    boiler.Fill();
    boiler.Boil();

    Assert.False(boiler.Empty);
    Assert.True(boiler.Boiled);
  }

  [Fact]
  public void TestDrain()
  {
    TestingChocolateBoiler.ResetInstance();
    var boiler = TestingChocolateBoiler.GetInstance();

    boiler.Fill();
    boiler.Boil();
    boiler.Drain();

    Assert.True(boiler.Empty);
    Assert.True(boiler.Boiled);
  }

  [Fact]
  public void TestHasOnlyOneInstance()
  {
    var firstItem = ChocolateBoiler.GetInstance();
    var secondItem = ChocolateBoiler.GetInstance();

    Assert.Equal(firstItem, secondItem);
  }
}