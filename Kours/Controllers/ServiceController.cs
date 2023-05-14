using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Service")]
    [ApiExplorerSettings(GroupName = "service")]
    public class ServiceController : Controller
    {
        private readonly ServiceDAL _dal;

        public ServiceController(ServiceDAL serviceDAL)
        {
            _dal = serviceDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Service>> NewService(Service service)
        {
            return await _dal.Add(service);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service?>> GetService(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutService")]
        public async Task<ActionResult<Service?>> PutService(Service service)
        {
            return await _dal.Update(service);
        }

        [HttpDelete("DeleteService/{id}")]
        public async Task<ActionResult<Service?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
