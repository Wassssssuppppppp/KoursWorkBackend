using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Sklad")]
    public class SkladController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public SkladController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Sklad[]>> GetSklads()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Sklad");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Sklad[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Sklad>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sklad?>> GetSklad(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Sklad/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Sklad?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Sklad?> PostSklad(Sklad newSklad)
        {
            JsonContent content = JsonContent.Create(newSklad);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Sklad", content);
            response.EnsureSuccessStatusCode();
            Sklad? sklad = await response.Content.ReadFromJsonAsync<Sklad>();

            return sklad;
        }

        [HttpDelete("{id}")]
        public async Task DeleteSklad(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Sklad/DeleteSklad/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutSklad(Sklad newSklad)
        {
            JsonContent content = JsonContent.Create(newSklad);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Sklad/PutSklad", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
