using System;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SumpThingApi.Clients;

namespace SumpThingApi.Controllers
{
  [Route ("/api/login")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly Auth0Client _client;

    public AuthController (Auth0Client client)
    {
      _client = client;
    }

    [HttpPost]
    public async Task<JObject> Post ([FromBody] JObject data)
    {
      string username = data["username"].ToString ();
      string password = data["password"].ToString ();

      JObject resp = await _client.Login (username, password);

      this.Response.Headers.Add ("Content-Type", "application/json");

      return resp;
    }
  }
}