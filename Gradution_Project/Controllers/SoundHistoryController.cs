using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gradution_Project.Data;
using Gradution_Project.models;
using Gradution_Project.DTOS;

namespace Gradution_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoundHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SoundHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<SoundHistoryReadDTO>> PostSound(SoundHistoryCreateDTO soundDto)
        {
           
            var user = await _context.Users.FindAsync(soundDto.Id);
            if (user == null) return BadRequest("User not found");

            
            var soundHistory = new Sound_History
            {
                
                user_id = soundDto.Id,
                sound_label = soundDto.sound_label,
                confidence = soundDto.confidence,
                timestamp = DateTime.Now
            };

            
            _context.Sound_Histories.Add(soundHistory);
            await _context.SaveChangesAsync();

            
            var readDto = new SoundHistoryReadDTO
            {
                LogId = soundHistory.log_id,
                SoundLabel = soundHistory.sound_label,
                Confidence = soundHistory.confidence,
                Timestamp = soundHistory.timestamp,
                Username = user.username
            };

            return Ok(readDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<SoundHistoryReadDTO>>> GetUserHistory(int userId)
        {
            var history = await _context.Sound_Histories
                .Where(s => s.user_id == userId)
                .OrderByDescending(s => s.timestamp)
                .Select(s => new SoundHistoryReadDTO
                {
                    LogId = s.log_id,
                    SoundLabel = s.sound_label,
                    Confidence = s.confidence,
                    Timestamp = s.timestamp,
                    
                    Username = s.Users != null ? s.Users.username : "Unknown"
                })
                .ToListAsync();

            return Ok(history);
        }
    }
}