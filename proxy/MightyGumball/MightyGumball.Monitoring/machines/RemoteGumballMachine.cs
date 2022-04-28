using System.Text.Json;

namespace MightyGumball.Monitoring.Machines;

public class RemoteGumballMachine : GumballMachine
{
  private string id;
  private HttpClient http;

  public RemoteGumballMachine(string id, HttpClient http)
  {
    this.id = id;
    this.http = http;
  }

  public string GetLocation()
  {
    var resp = this.PerformGetRequest(resource: "location");
    var deserializedResp = JsonSerializer.Deserialize<string>(resp.Content.ReadAsStream());
    return String.IsNullOrEmpty(deserializedResp) ? "" : deserializedResp;
  }

  public int GetGumballCount()
  {
    var resp = this.PerformGetRequest(resource: "gumball-count");
    return Convert.ToInt32(JsonSerializer.Deserialize<string>(resp.Content.ReadAsStream()));
  }

  private HttpResponseMessage PerformGetRequest(string resource)
  {
    var msg = new HttpRequestMessage();
    msg.Method = HttpMethod.Get;
    msg.RequestUri = new Uri($"https://mightygumball.co.uk/${this.id}/{resource}");
    return this.http.Send(msg);
  }
}