using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            List<AppUser> users = await context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")] // api/users/1
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
        {
            AppUser? user = await context.Users.FindAsync(id);

            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
