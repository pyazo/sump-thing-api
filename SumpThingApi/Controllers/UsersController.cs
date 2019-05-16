using System.Linq;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumpThingApi.Models;

namespace SumpThingApi.Controllers
{
  [Route ("/api/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly ApiDbContext db;

    public UsersController (ApiDbContext context)
    {
      db = context;
    }

    [HttpGet]
    public object Get ()
    {
      return db.Users
        .Include (u => u.UserAccounts)
        .ThenInclude (ua => ua.Account)
        .ThenInclude (a => a.Tanks)
        .ThenInclude (t => t.Parameters)
        .ThenInclude (p => p.Values)
        .ToList ();
    }

    [HttpGet ("{id}")]
    [Authorize]
    public object Get (int id)
    {
      return db.Users
        .Where (u => u.Id == id)
        .Include (u => u.UserAccounts)
        .ThenInclude (ua => ua.Account)
        .ThenInclude (a => a.Tanks)
        .ToList ();
    }
  }
}