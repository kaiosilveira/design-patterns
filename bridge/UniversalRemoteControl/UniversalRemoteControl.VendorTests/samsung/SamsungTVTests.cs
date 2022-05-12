using Xunit;
using UniversalRemoteControl.Domain;
using UniversalRemoteControl.Vendors.Samsung;

namespace UniversalRemoteControl.VendorTests.Samsung;

public class SamsungTVTests
{
  [Fact]
  public void TestOn()
  {
    var tv = new SamsungTV();

    tv.On();

    Assert.True(tv.IsOn);
  }

  [Fact]
  public void TestStartsWithDefaultChannelSelected()
  {
    var tv = new SamsungTV();

    tv.On();

    var defaultChannel = new NoChannel();
    Assert.Equal(defaultChannel.Label, tv.CurrentChannel.Label);
    Assert.Equal(defaultChannel.Number, tv.CurrentChannel.Number);
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
  public void TestTuneChannel()
  {
    var tv = new SamsungTV();
    var channel = new TVChannel(number: 5, label: "Globo");

    tv.TuneChannel(channel);

    Assert.Equal(channel.Label, tv.CurrentChannel.Label);
    Assert.Equal(channel.Number, tv.CurrentChannel.Number);
  }
}