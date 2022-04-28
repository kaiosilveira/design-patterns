using Xunit;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using MightyGumball.Monitoring.Machines;

public class RemoteGumballMachineTest
{
  [Fact]
  public void TestGetLocation()
  {
    var httpHandler = new Mock<HttpClientHandler>();

    httpHandler
      .Protected()
      .SetupSequence<HttpResponseMessage>(
        "Send", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()
      ).Returns(new HttpResponseMessage
      {
        StatusCode = HttpStatusCode.OK,
        Content = JsonContent.Create("Lisbon")
      });

    var machine = new RemoteGumballMachine(
      id: "lisbon-machine-id",
      new HttpClient(httpHandler.Object)
    );

    var receivedLocation = machine.GetLocation();

    Assert.Equal("Lisbon", receivedLocation);
  }

  [Fact]
  public void TestGetCount()
  {
    var httpHandler = new Mock<HttpClientHandler>();

    httpHandler
      .Protected()
      .SetupSequence<HttpResponseMessage>
      (
        "Send", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>()
      )
      .Returns(new HttpResponseMessage
      {
        StatusCode = HttpStatusCode.OK,
        Content = JsonContent.Create("100")
      });

    var machine = new RemoteGumballMachine(
      id: "lisbon-machine-id",
      new HttpClient(httpHandler.Object)
    );

    var receivedCount = machine.GetGumballCount();

    Assert.Equal(100, receivedCount);
  }
}