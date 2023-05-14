using Kours.DAL.DAL;
using Kours.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Post")]
    [ApiExplorerSettings(GroupName = "post")]
    public class PostController : Controller
    {
        private readonly PostDAL _dal;

        public PostController(PostDAL postDAL)
        {
            _dal = postDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Post>> NewPost(Post post)
        {
            return await _dal.Add(post);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post?>> GetPost(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutPost")]
        public async Task<ActionResult<Post?>> PutPost(Post post)
        {
            return await _dal.Update(post);
        }

        [HttpDelete("DeletePost/{id}")]
        public async Task<ActionResult<Post?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
