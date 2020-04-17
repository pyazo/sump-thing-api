using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using SumpThingApi.Models;

namespace SumpThingApi.Controllers
{
  [Route ("/api/boxes")]
  [ApiController]
  public class SumpThingBoxController : ControllerBase
  {
    private readonly ApiDbContext db;

    public SumpThingBoxController(ApiDbContext context)
    {
      db = context;
    }

      [HttpPost("register")]
      [Authorize]
      public object Register([FromBody] JObject data)
      {
        string uuid = data["uuid"].ToString ();

        string auth0Token = User.FindFirst("sub")?.Value;

        User user  = db.Users
          .Where (u => u.Auth0Token == auth0Token)
          .Include(u => u.UserAccounts)
          .ThenInclude(ua => ua.Account)
          .Single ();

        SumpThingBox sumpThingBox = new SumpThingBox {
          UUID = uuid,
          TankId = null,
        };

        db.SumpThingBoxes.Add(sumpThingBox);

        Registration registration = new Registration {
          AccountId = user.UserAccounts[0].Account.Id,
          SumpThingBoxId = sumpThingBox.Id,
        };

        db.Registrations.Add(registration);

        db.SaveChanges ();

        return registration;
      }
  }
}