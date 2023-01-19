using backend.Data;
using backend.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DContext _context;
        public UsersController(DContext context)
        {
            _context = context;
            
        }
        [AllowAnonymous]
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

        [HttpGet("{carid}")]
        public async Task<ActionResult<CarsClass>> GetCar(int carId)
        {
            var car=await _context.Cars.FindAsync(carId);
            return car;
        }
    }
}