using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gradution_Project.Data;
using Gradution_Project.models;
using Gradution_Project.DTOS;

namespace Gradution_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDTO>>> GetUsers()
        {
            return await _context.Users
                .Select(user => new UserReadDTO
                {
                    Id = user.user_id,
                    Username = user.username,
                    Email = user.email,
                    Role = user.role
                }).ToListAsync();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return NotFound();

            return new UserReadDTO
            {
                Id = user.user_id,
                Username = user.username,
                Email = user.email,
                Role = user.role
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserRegistrationDTO userDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            
            user.username = userDto.Username;
            user.email = userDto.Email;
            user.password = userDto.Password;
            user.role = userDto.Role;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        
        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> PostUser(UserRegistrationDTO userDto)
        {
            var user = new User
            {
                username = userDto.Username,
                email = userDto.Email,
                password = userDto.Password,
                role = userDto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            
            var userReadDto = new UserReadDTO
            {
                Id = user.user_id,
                Username = user.username,
                Email = user.email,
                Role = user.role
            };

            return CreatedAtAction("GetUser", new { id = user.user_id }, userReadDto);
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.user_id == id);
        }
    }
}