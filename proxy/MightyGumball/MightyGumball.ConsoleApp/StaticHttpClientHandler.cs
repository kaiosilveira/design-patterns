using System.Net.Http.Json;

namespace MightyGumball.ConsoleApp;

public class StaticHttpClientHandler : HttpClientHandler
{
  private List<string> responses;

  public StaticHttpClientHandler(List<string> responses)
  {
    this.responses = responses;
  }

  protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    var resp = new HttpResponseMessage();
    var content = this.responses.ElementAt(0);
    this.responses.RemoveAt(0);

    resp.Content = JsonContent.Create(content);

    return resp;
  }
}
