using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskService.Data;
using TaskService.Models;

namespace TaskService.Controllers
{
    [Route("tasks")]
    [ApiController]
    public class TasksController0013 : ControllerBase
    {
        private readonly TaskDbContext0013 _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public TasksController0013(TaskDbContext0013 context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // POST /tasks
        [HttpPost]
        public async Task<ActionResult<WeddingTask0013>> CreateTask0013([FromBody] WeddingTask0013 task0013)
        {
            // Validate event exists by calling EventService
            var client = _httpClientFactory.CreateClient("EventService");
            var response = await client.GetAsync($"/events/{task0013.EventId}");

            if (!response.IsSuccessStatusCode)
                return BadRequest("Event does not exist");

            _context.Tasks.Add(task0013);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask0013), new { id = task0013.TaskId }, task0013);
        }

        // GET /tasks/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WeddingTask0013>> GetTask0013(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            return task;
        }

        // GET /tasks?eventId={id}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeddingTask0013>>> GetTasksByEvent0013([FromQuery] int? eventId)
        {
            if (eventId.HasValue)
                return await _context.Tasks.Where(t => t.EventId == eventId.Value).ToListAsync();

            return await _context.Tasks.ToListAsync();
        }

        // PUT /tasks/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask0013(int id, [FromBody] WeddingTask0013 task0013)
        {
            if (id != task0013.TaskId)
                return BadRequest();

            _context.Entry(task0013).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /tasks/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask0013(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}