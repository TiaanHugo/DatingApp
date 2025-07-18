using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController(DataContext context) : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            List<AppUser> users = await context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")] // api/users/1
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
