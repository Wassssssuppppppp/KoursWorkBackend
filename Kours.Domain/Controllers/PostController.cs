using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Kours.Domain.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/Domain/Post")]
    public class PostController : ControllerBase
    {
        private readonly string? _DalConnectionString;
        private readonly HttpClient _client;

        public PostController(IConfiguration conf)
        {
            _DalConnectionString = conf.GetValue<string>("DalConnectionString");
            _client = new HttpClient();
        }

        [HttpGet]
        public async Task<ActionResult<Post[]>> GetPosts()
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Post");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Post[]>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Array.Empty<Post>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post?>> GetPost(int id)
        {
            var response = await _client.GetAsync($"{_DalConnectionString}/api/Post/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (content == null) return NotFound();

            return JsonSerializer.Deserialize<Post?>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        [HttpPost]
        public async Task<Post?> AddPost(Post newPost)
        {
            JsonContent content = JsonContent.Create(newPost);
            var response = await _client.PostAsync($"{_DalConnectionString}/api/Post", content);
            response.EnsureSuccessStatusCode();
            Post? post = await response.Content.ReadFromJsonAsync<Post>();

            return post;
        }

        [HttpDelete("{id}")]
        public async Task DeletePost(int id)
        {
            var response = await _client.DeleteAsync($"{_DalConnectionString}/api/Post/DeletePost/{id}");
            response.EnsureSuccessStatusCode();
        }

        [HttpPut]
        public async Task PutPost(Post newPost)
        {
            JsonContent content = JsonContent.Create(newPost);
            var response = await _client.PutAsync($"{_DalConnectionString}/api/Post/PutPost", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
