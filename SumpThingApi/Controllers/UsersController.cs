using SumpThingApi.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Text.Encodings.Web;
using System.Linq;


namespace SumpThingApi.Controllers {
  [Route("/api/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly ApiDbContext db;

    public UsersController(ApiDbContext context) {
      db = context;
    }

    [HttpGet]
    public object Get() {
      return db.Users
        .Select(u => new {
          Id = u.Id,
          Auth0Token = u.Auth0Token,
          FirstName = u.FirstName,
          LastName = u.LastName,
          Email = u.Email,
          PhoneNumber = u.PhoneNumber,
          UserAccounts = u.UserAccounts.Select(ua => ua.Account).Select(a => new { Id = a.Id, ResourceType = a.ResourceType, ResourceId = a.ResourceId })
        })
        .ToList();
    }

    [HttpGet("{id}")]
    public object Get(int id) {
      return db.Users
        .Where(u => u.Id == id)
        .Select(u => new {
          Id = u.Id,
          Auth0Token = u.Auth0Token,
          FirstName = u.FirstName,
          LastName = u.LastName,
          Email = u.Email,
          PhoneNumber = u.PhoneNumber,
          UserAccounts = u.UserAccounts.Select(ua => ua.Account).Select(a => new { Id = a.Id, ResourceType = a.ResourceType, ResourceId = a.ResourceId })
        })
        .ToList();
    }
  }
}