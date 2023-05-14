using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/StoreAddress")]
    [ApiExplorerSettings(GroupName = "storeAddress")]
    public class StoreAddressController : Controller
    {
        private readonly StoreAddressDAL _dal;

        public StoreAddressController(StoreAddressDAL storeAddressDAL)
        {
            _dal = storeAddressDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreAddress>>> GetStoreAddress()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<StoreAddress>> NewStoreAddress(StoreAddress storeAddress)
        {
            return await _dal.Add(storeAddress);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreAddress?>> GetStoreAddres(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutStoreAddress")]
        public async Task<ActionResult<StoreAddress?>> PutStoreAddress(StoreAddress storeAddress)
        {
            return await _dal.Update(storeAddress);
        }

        [HttpDelete("DeleteStoreAddress/{id}")]
        public async Task<ActionResult<StoreAddress?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
