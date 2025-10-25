using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ApiGateway.Controllers
{
    [Route("gateway")]
    [ApiController]
    public class GatewayController0013 : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GatewayController0013(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // POST /gateway/events
        [HttpPost("events")]
        public async Task<IActionResult> CreateEvent0013([FromBody] JsonElement eventData)
        {
            var client = _httpClientFactory.CreateClient("EventService");
            var response = await client.PostAsJsonAsync("/events", eventData);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, JsonSerializer.Deserialize<JsonElement>(content));
        }

        // GET /gateway/events/{id}
        [HttpGet("events/{id}")]
        public async Task<IActionResult> GetEvent0013(int id)
        {
            var client = _httpClientFactory.CreateClient("EventService");
            var response = await client.GetAsync($"/events/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, JsonSerializer.Deserialize<JsonElement>(content));
        }

        // POST /gateway/guests
        [HttpPost("guests")]
        public async Task<IActionResult> CreateGuest0013([FromBody] JsonElement guestData)
        {
            var client = _httpClientFactory.CreateClient("GuestService");
            var response = await client.PostAsJsonAsync("/guests", guestData);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, JsonSerializer.Deserialize<JsonElement>(content));
        }

        // POST /gateway/tasks
        [HttpPost("tasks")]
        public async Task<IActionResult> CreateTask0013([FromBody] JsonElement taskData)
        {
            var client = _httpClientFactory.CreateClient("TaskService");
            var response = await client.PostAsJsonAsync("/tasks", taskData);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, JsonSerializer.Deserialize<JsonElement>(content));
        }

        // GET /gateway/summary/{eventId}
        [HttpGet("summary/{eventId}")]
        public async Task<IActionResult> GetSummary0013(int eventId)
        {
            var eventClient = _httpClientFactory.CreateClient("EventService");
            var guestClient = _httpClientFactory.CreateClient("GuestService");
            var taskClient = _httpClientFactory.CreateClient("TaskService");

            var eventResponse = await eventClient.GetAsync($"/events/{eventId}");
            var guestsResponse = await guestClient.GetAsync($"/guests?eventId={eventId}");
            var tasksResponse = await taskClient.GetAsync($"/tasks?eventId={eventId}");

            var eventData = await eventResponse.Content.ReadAsStringAsync();
            var guestsData = await guestsResponse.Content.ReadAsStringAsync();
            var tasksData = await tasksResponse.Content.ReadAsStringAsync();

            var summary = new
            {
                @event = JsonSerializer.Deserialize<JsonElement>(eventData),
                guests = JsonSerializer.Deserialize<JsonElement>(guestsData),
                tasks = JsonSerializer.Deserialize<JsonElement>(tasksData)
            };

            return Ok(summary);
        }
    }
}