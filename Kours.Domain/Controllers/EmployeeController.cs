using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Route("api/Domain/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public EmployeeController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Employee[]>> GetEmployees()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Employee");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Employee[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Employee>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> GetEmployee(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Employee/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Employee?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Employee?> PostEmployee(Employee newEmployee)
        {
            JsonContent content = JsonContent.Create(newEmployee);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Employee", content);
            response.EnsureSuccessStatusCode();
            Employee? employee = await response.Content.ReadFromJsonAsync<Employee>();

            return employee;
        }

        [HttpDelete("{id}")]
        public async Task DeleteEmployee(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Employee/DeleteEmployee/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutEmployee(Employee newEmployee)
        {
            JsonContent content = JsonContent.Create(newEmployee);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Client/PutEmployee", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
