using Kours.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Product")]
    public class ProductController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public ProductController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Product[]>> GetProducts()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Product");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Product[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Product>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProduct(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Product/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Product?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Product?> PostProduct(Product newProduct)
        {
            JsonContent content = JsonContent.Create(newProduct);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Product", content);
            response.EnsureSuccessStatusCode();
            Product? product = await response.Content.ReadFromJsonAsync<Product>();

            return product;
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Product/DeleteProduct/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutProduct(Product newProduct)
        {
            JsonContent content = JsonContent.Create(newProduct);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Product/PutProduct", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
