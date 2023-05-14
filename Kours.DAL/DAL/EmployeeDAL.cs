using Kours.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL.DAL
{
    public class EmployeeDAL
    {
        private readonly MVCFlowersDbContext _db;

        public EmployeeDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _db.Employee.ToListAsync();

        }

        public async Task<Employee> Add(Employee newEmployee)
        {
            var dbEmployee = new Employee()
            {
                Id = newEmployee.Id,
                FIOemployee = newEmployee.FIOemployee,
                PostId = newEmployee.PostId
            };

            await _db.Employee.AddAsync(dbEmployee);
            await _db.SaveChangesAsync();
            return dbEmployee;
        }

        public async Task<Employee?> Get(int id)
        {
            return await _db.Employee.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee?> Update(Employee employee)
        {
            var dbEmployee = await Get(employee.Id);
            if (dbEmployee != null)
            {
                dbEmployee.FIOemployee = employee.FIOemployee;
                dbEmployee.PostId = employee.PostId;

                await _db.SaveChangesAsync();
                return dbEmployee;
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee?> Delete(int id)
        {
            var dbEmployee = await Get(id);

            if (dbEmployee != null)
            {
                _db.Employee.Remove(dbEmployee);
                await _db.SaveChangesAsync();
                return dbEmployee;
            }
            else
            {
                return null;
            }
        }
    }
}
