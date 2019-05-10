using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

namespace SumpThingApi.Clients {
  public class Auth0Client {
  public HttpClient Client { get; private set; }

  public Auth0Client(HttpClient client) {
    client.BaseAddress = new Uri($"https://{Environment.GetEnvironmentVariable("AUTH0_DOMAIN")}/oauth/token/");
    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

    Client = client;
  }

  public async Task<JObject> Login(String username, String password) {
    var options = new {
      scope = "openid read:current_user profile",
      audience = Environment.GetEnvironmentVariable("AUTH0_API_ID"),
      grant_type = "password",
      username = username,
      password = password,
      client_id = Environment.GetEnvironmentVariable("AUTH0_CLIENT_ID"),
      client_secret = Environment.GetEnvironmentVariable("AUTH0_CLIENT_SECRET")
    };

    HttpResponseMessage response = await Client.PostAsJsonAsync("", options);

    string resp = await response.Content.ReadAsStringAsync();

    JObject json = JObject.Parse(resp);

    return json;
  }
}
}