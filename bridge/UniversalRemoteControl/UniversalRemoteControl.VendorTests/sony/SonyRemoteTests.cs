using Xunit;
using UniversalRemoteControl.Domain;
using UniversalRemoteControl.Vendors.Sony;

namespace UniversalRemoteControl.VendorTests.Sony;

public class SonyRemoteTests
{
  [Fact]
  public void TestOn()
  {
    var tv = new SonyTV();
    var remote = new SonyRemote(tv);

    remote.On();

    Assert.True(tv.IsOn);
  }

  [Fact]
  public void TestOff()
  {
    var tv = new SonyTV();
    var remote = new SonyRemote(tv);
    remote.On();

    remote.Off();

    Assert.False(tv.IsOn);
  }

  [Fact]
  public void TestSetChannel()
  {
    var tv = new SonyTV();
    var remote = new SonyRemote(tv);
    var channel = new TVChannel(number: 5, label: "Globo");

    remote.SetChannel(channel);

    Assert.Equal(channel.Label, tv.CurrentChannel.Label);
    Assert.Equal(channel.Number, tv.CurrentChannel.Number);
  }
}