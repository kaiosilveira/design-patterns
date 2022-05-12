using Xunit;
using UniversalRemoteControl.Domain;

namespace UniversalRemoteControl.DomainTests;

public class NoChannelTests
{
  [Fact]
  public void TestContainsDefaultInfo()
  {
    var channel = new NoChannel();
    Assert.Equal("No channel selected", channel.Label);
    Assert.Equal(0, channel.Number);
  }
}