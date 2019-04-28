using SumpThingApi.Models;

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
      return db.Users.ToList();
    }

    [HttpGet("{id}")]
    public object Get(int id) {
      return db.Users.Where(u => u.Id == id).ToList();
    }
  }
}
