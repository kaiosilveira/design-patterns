using Xunit;
using UniversalRemoteControl.Domain;
using UniversalRemoteControl.Vendors.Samsung;

namespace UniversalRemoteControl.VendorTests.Samsung;

public class SamsungRemoteTests
{
  [Fact]
  public void TestOn()
  {
    var tv = new SamsungTV();
    var remote = new SamsungRemote(tv);

    remote.On();

    Assert.True(tv.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var tv = new SamsungTV();
    var remote = new SamsungRemote(tv);
    remote.On();

    remote.Off();

    Assert.False(tv.IsOn);
  }

  [Fact]
  public void TestSetChannel()
  {
    var tv = new SamsungTV();
    var remote = new SamsungRemote(tv);
    var channel = new TVChannel(number: 5, label: "Globo");

    remote.SetChannel(channel);

    Assert.Equal(channel.Label, tv.CurrentChannel.Label);
    Assert.Equal(channel.Number, tv.CurrentChannel.Number);
  }
}