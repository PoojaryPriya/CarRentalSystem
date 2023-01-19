using System.Net.Sockets;
using backend.Data;
using backend.DTOs;
using backend.Entities;
using backend.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DContext _context;
        private readonly ITokenservices _tokenservices;
        public AccountController(DContext context,ITokenservices tokenservices)
        {
            _tokenservices = tokenservices;
            _context = context;
            
        }

        [HttpPost("admin/login")]
        public async Task<ActionResult<AdminDto>> adminLogin(AdminLoginDto adminLoginDto)
        {
            var admin= await _context.Admin.SingleOrDefaultAsync(x=>x.Username==adminLoginDto.Username);
            if(admin.Username!="admin"|| admin.Password!="Pa$$w0rd") 
            {
                return BadRequest("Wrong data");
            }else
            {
            return new AdminDto{
                username=admin.Username,
                Role="admin"
            };
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDtos>> Login(LoginDTOs loginDTOs)
        {
            var user= await _context.Users.SingleOrDefaultAsync(x=>x.UserName==loginDTOs.Username);

            if(user==null) return Unauthorized("Inavalid username ");

            if(user.Password!=loginDTOs.Password) return Unauthorized("Invalid password");

            return new UserDtos
            {
                Username=user.UserName,
                Token=_tokenservices.CreateToken(user)
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserClass>> Register(RegisterDtos registerDtos)
        {
            if(registerDtos==null)
            {
                return BadRequest();
            }
            var user= _context.Users.FirstOrDefault(x=>x.UserName==registerDtos.Username);
            if(user != null)
            {
                return Conflict();
            }
            var newuser= new UserClass();
            newuser.UserName=registerDtos.Username;
            newuser.Password=registerDtos.Password;
            newuser.Address=registerDtos.Address;
            newuser.PhoneNo=registerDtos.Phoneno;
            newuser.Role="User";
            _context.Users.Add(newuser);
            var result= await _context.SaveChangesAsync();
            return newuser;
        }


        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x=>x.UserName==username.ToLower());
        }
    }
}