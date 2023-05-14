using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Sklad")]
    [ApiExplorerSettings(GroupName = "sklad")]
    public class SkladController : Controller
    {
        private readonly SkladDAL _dal;

        public SkladController(SkladDAL skladDAL)
        {
            _dal = skladDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sklad>>> GetSklads()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Sklad>> NewSklad(Sklad sklad)
        {
            return await _dal.Add(sklad);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sklad?>> GetSklad(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutService")]
        public async Task<ActionResult<Sklad?>> PutService(Sklad sklad)
        {
            return await _dal.Update(sklad);
        }

        [HttpDelete("DeleteService/{id}")]
        public async Task<ActionResult<Sklad?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }
}
