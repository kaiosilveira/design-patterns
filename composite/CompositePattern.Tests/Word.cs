using System;
using Xunit;
using CompositePattern.Console;

namespace CompositePattern.Tests;

public class WordTest
{
  [Fact]
  public void TestRendersEmptyStringIfNoValueWasPassed()
  {
    Assert.Equal("", new Word().Render());
  }

  [Fact]
  public void TestRendersGivenValue()
  {
    var value = "Kaio";
    var word = new Word(value);
    Assert.Equal(value, word.Render());
  }

  [Fact]
  public void TestThrowsErrorIfAddIsCalled()
  {
    var word = new Word("");
    Assert.Throws<NotImplementedException>(() => word.Add(new Word("a")));
  }
}