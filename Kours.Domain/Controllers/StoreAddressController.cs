using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/StoreAddress")]
    public class StoreAddressController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public StoreAddressController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<StoreAddress[]>> GetStoreAddress()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/StoreAddress");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<StoreAddress[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<StoreAddress>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreAddress?>> GetStoreAddres(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/StoreAddress/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<StoreAddress?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<StoreAddress?> PostStoreAddress(StoreAddress newStoreAddress)
        {
            JsonContent content = JsonContent.Create(newStoreAddress);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/StoreAddress", content);
            response.EnsureSuccessStatusCode();
            StoreAddress? storeAddress = await response.Content.ReadFromJsonAsync<StoreAddress>();

            return storeAddress;
        }

        [HttpDelete("{id}")]
        public async Task DeleteStoreAddress(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/StoreAddress/DeleteStoreAddress/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutStoreAddress(StoreAddress newStoreAddress)
        {
            JsonContent content = JsonContent.Create(newStoreAddress);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/StoreAddress/PutStoreAddress", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
