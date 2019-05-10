using SumpThingApi.Clients;

using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using System.Text.Encodings.Web;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace SumpThingApi.Controllers {
  [Route("/api/login")]
  [ApiController]
  public class LoginController : ControllerBase {
    private Auth0Client _client;

    public LoginController(Auth0Client client) {
      _client = client;
    }

    [HttpPost]
    public async Task<string> Post([FromBody] JObject data) {
      string username = data["username"].ToString();
      string password = data["password"].ToString();

      var resp = await _client.Login(username, password);

      return resp;
    }
  }
}