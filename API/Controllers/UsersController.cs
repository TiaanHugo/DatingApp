using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController(DataContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    [HttpGet("{id:int}")] // /api/user/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        if (await context.Users.FindAsync(id) != null)
            return await context.Users.FindAsync(id);
        else return BadRequest();
    }
}
