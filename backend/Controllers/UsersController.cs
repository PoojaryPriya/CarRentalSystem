using backend.Data;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DContext _context;
        public UsersController(DContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClass>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserClass>> GetUser(int Id)
        {
            var user=await _context.Users.FindAsync(Id);

            return user;
        }
    }
}