using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventService.Data;
using EventService.Models;

namespace EventService.Controllers
{
    [Route("events")]
    [ApiController]
    public class EventsController0013 : ControllerBase
    {
        private readonly EventDbContext0013 _context;

        public EventsController0013(EventDbContext0013 context)
        {
            _context = context;
        }

        // POST /events
        [HttpPost]
        public async Task<ActionResult<Event0013>> CreateEvent0013([FromBody] Event0013 event0013)
        {
            _context.Events.Add(event0013);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent0013), new { id = event0013.EventId }, event0013);
        }

        // GET /events/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Event0013>> GetEvent0013(int id)
        {
            var event0013 = await _context.Events.FindAsync(id);
            if (event0013 == null)
                return NotFound();

            return event0013;
        }

        // GET /events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event0013>>> GetAllEvents0013()
        {
            return await _context.Events.ToListAsync();
        }

        // PUT /events/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent0013(int id, [FromBody] Event0013 event0013)
        {
            if (id != event0013.EventId)
                return BadRequest();

            _context.Entry(event0013).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /events/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent0013(int id)
        {
            var event0013 = await _context.Events.FindAsync(id);
            if (event0013 == null)
                return NotFound();

            _context.Events.Remove(event0013);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}