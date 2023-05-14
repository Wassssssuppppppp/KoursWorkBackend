using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Service")]
    public class ServiceController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public ServiceController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Service[]>> GetServices()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Service");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Service[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Service>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service?>> GetService(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Service/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Service?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Service?> PostService(Service newService)
        {
            JsonContent content = JsonContent.Create(newService);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Service", content);
            response.EnsureSuccessStatusCode();
            Service? service = await response.Content.ReadFromJsonAsync<Service>();

            return service;
        }

        [HttpDelete("{id}")]
        public async Task DeleteService(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Service/DeleteService/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutService(Service newService)
        {
            JsonContent content = JsonContent.Create(newService);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Service/PutService", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
