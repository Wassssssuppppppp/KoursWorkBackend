using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Zakaz")]
    [ApiExplorerSettings(GroupName = "zakaz")]
    public class ZakazController : Controller
    {
        private readonly ZakazDAL _dal;

        public ZakazController(ZakazDAL zakazDAL)
        {
            _dal = zakazDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zakaz>>> GetZakazs()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Zakaz>> NewSklad(Zakaz zakaz)
        {
            return await _dal.Add(zakaz);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Zakaz?>> GetSklad(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutService")]
        public async Task<ActionResult<Zakaz?>> PutService(Zakaz zakaz)
        {
            return await _dal.Update(zakaz);
        }

        [HttpDelete("DeleteService/{id}")]
        public async Task<ActionResult<Zakaz?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}

