using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Zakaz")]
    public class ZakazController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public ZakazController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Zakaz[]>> GetZakazs()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Zakaz");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Zakaz[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Zakaz>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zakaz?>> GetZakaz(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Zakaz/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Zakaz?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Zakaz?> PostZakaz(Zakaz newZakaz)
        {
            JsonContent content = JsonContent.Create(newZakaz);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Zakaz", content);
            response.EnsureSuccessStatusCode();
            Zakaz? zakaz = await response.Content.ReadFromJsonAsync<Zakaz>();

            return zakaz;
        }

        [HttpDelete("{id}")]
        public async Task DeleteZakaz(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Zakaz/DeleteZakaz/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutZakaz(Zakaz newZakaz)
        {
            JsonContent content = JsonContent.Create(newZakaz);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Zakaz/PutZakaz", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
