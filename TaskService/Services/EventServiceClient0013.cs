namespace TaskService.Services
{
    public class EventServiceClient0013
    {
        private readonly HttpClient _httpClient;
        private readonly string _eventServiceUrl = "http://localhost:5001";

        public EventServiceClient0013(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_eventServiceUrl);
        }

        public async Task<bool> ValidateEventExists0013(int eventId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/events/{eventId}");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}