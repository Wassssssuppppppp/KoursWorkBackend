using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Client")]
    [ApiExplorerSettings(GroupName = "client")]
    public class ClientController : Controller
    {
        private readonly ClientDAL _dal;

        public ClientController(ClientDAL clientDAL)
        {
            _dal = clientDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            return await _dal.Add(client);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client?>> GetClient(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutClient")]
        public async Task<ActionResult<Client?>> PutClient(Client model)
        {
            return await _dal.Update(model);
        }

        [HttpDelete("DeleteClient/{id}")]
        public async Task<ActionResult<Client?>> Delete(int id)
        {
             return await _dal.Delete(id);
        }
    }

}

