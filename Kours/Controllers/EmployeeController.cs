using Microsoft.AspNetCore.Mvc;
using Kours.DAL.DAL;
using Kours.Domain;

namespace Kours.Controllers
{
    [ApiController]
    [Route("api/Employee")]
    [ApiExplorerSettings(GroupName = "employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDAL _dal;

        public EmployeeController(EmployeeDAL employeeDAL)
        {
            _dal = employeeDAL;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _dal.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            return await _dal.Add(employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee?>> GetClient(int id)
        {
            return await _dal.Get(id);
        }

        [HttpPut("PutEmployee")]
        public async Task<ActionResult<Employee?>> PutClient(Employee employee)
        {
            return await _dal.Update(employee);
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<ActionResult<Employee?>> Delete(int id)
        {
            return await _dal.Delete(id);
        }
    }

}

