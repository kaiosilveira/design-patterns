using System;
using System.Linq;
using Xunit;
using CompositePattern.Console;

namespace CompositePattern.Tests;

public class ParagraphTest
{
  [Fact]
  public void TestRendersAnEmptyStringIfNoWordsWasAdded()
  {
    Assert.Equal("", new Paragraph().Render());
  }

  [Fact]
  public void TestRendersSingleWord()
  {
    var value = "Kaio";
    var word = new Word(value);
    var paragraph = new Paragraph();

    paragraph.Add(word);

    Assert.Equal(value, paragraph.Render());
  }

  [Fact]
  public void TestRendersMultipleWords()
  {
    var firstValue = "Kaio";
    var firstWord = new Word(firstValue);

    var secondValue = "Silveira";
    var secondWord = new Word(secondValue);

    var paragraph = new Paragraph();
    paragraph.Add(firstWord);
    paragraph.Add(secondWord);

    Assert.Equal($"{firstWord.Render()}{secondWord.Render()}", paragraph.Render());
  }
}