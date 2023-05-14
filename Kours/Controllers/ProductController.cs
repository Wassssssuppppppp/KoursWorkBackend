using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain.Models;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Product")]
    [ApiExplorerSettings(GroupName = "product")]
    public class ProductController : Controller
    {
        private readonly ProductDAL _dal;

        public ProductController(ProductDAL productDAL)
        {
            _dal = productDAL;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> NewProduct(Product product)
        {
            return await _dal.Add(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetProductt(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutProduct")]
        public async Task<ActionResult<Product?>> PutPost(Product product)
        {
            return await _dal.Update(product);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<Product?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
