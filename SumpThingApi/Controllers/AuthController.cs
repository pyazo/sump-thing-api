using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SumpThingApi.Clients;
using SumpThingApi.Models;

namespace SumpThingApi.Controllers
{
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly Auth0Client _client;
    private readonly ApiDbContext db;

    public AuthController (Auth0Client client, ApiDbContext context)
    {
      _client = client;
      db = context;
    }

    [HttpGet("/api/validate_token")]
    [Authorize]
    public string ValidateToken()
    {
      return "Token valid.";
    }

    [HttpPost("/api/login")]
    public async Task<JObject> Login ([FromBody] JObject data)
    {
      string username = data["username"].ToString ();
      string password = data["password"].ToString ();

      JObject resp = await _client.Login (username, password);

      this.Response.Headers.Add ("Content-Type", "application/json");

      return resp;
    }

    [HttpPost("/api/signup")]
    public async Task<object> Signup ([FromBody] JObject data)
    {
      string first_name = data["first_name"].ToString ();
      string last_name = data["last_name"].ToString ();
      string email = data["email"].ToString ();
      string password = data["password"].ToString ();

      JObject resp = await _client.Register(first_name, last_name, email, password);

      this.Response.Headers.Add("Content-Type", "application/json");

      int statusCode = resp["statusCode"].ToObject<int> ();

      if (statusCode >= 400) {
        this.HttpContext.Response.StatusCode = statusCode;

        return resp;
      }

      User user = new User{
        Auth0Token = $"auth0|{resp["_id"].ToString ()}",
        FirstName = first_name,
        LastName = last_name,
        Email = email
      };

      db.Users.Add(user);
      db.SaveChanges();

      Account account = new Account
      {
        ResourceType = "user",
        ResourceId = user.Id
      };

      db.Accounts.Add(account);
      db.SaveChanges();

      UserAccount userAccount = new UserAccount
        {
          UserId = user.Id,
          AccountId = account.Id
        };

      db.UserAccounts.Add(userAccount);
      db.SaveChanges();

      return db.Users
        .Where (u => u.Id == user.Id)
        .Include (u => u.UserAccounts)
        .ThenInclude (ua => ua.Account)
        .ThenInclude (a => a.Tanks)
        .ToList ();
    }
  }
}