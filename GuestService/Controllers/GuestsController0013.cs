using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuestService.Data;
using GuestService.Models;

namespace GuestService.Controllers
{
    [Route("guests")]
    [ApiController]
    public class GuestsController0013 : ControllerBase
    {
        private readonly GuestDbContext0013 _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestsController0013(GuestDbContext0013 context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // POST /guests
        [HttpPost]
        public async Task<ActionResult<Guest0013>> CreateGuest0013([FromBody] Guest0013 guest0013)
        {
            // Validate event exists by calling EventService
            var client = _httpClientFactory.CreateClient("EventService");
            var response = await client.GetAsync($"/events/{guest0013.EventId}");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Event does not exist");

            _context.Guests.Add(guest0013);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGuest0013), new { id = guest0013.GuestId }, guest0013);
        }

        // GET /guests/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Guest0013>> GetGuest0013(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
                return NotFound();

            return guest;
        }

        // GET /guests?eventId={id}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest0013>>> GetGuestsByEvent0013([FromQuery] int? eventId)
        {
            if (eventId.HasValue)
                return await _context.Guests.Where(g => g.EventId == eventId.Value).ToListAsync();

            return await _context.Guests.ToListAsync();
        }

        // PUT /guests/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuest0013(int id, [FromBody] Guest0013 guest0013)
        {
            if (id != guest0013.GuestId)
                return BadRequest();

            _context.Entry(guest0013).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /guests/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest0013(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
                return NotFound();

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}