using Kours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{

    public class ServiceDAL
    {
        private readonly MVCFlowersDbContext _db;

        public ServiceDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Service>> GetAll()
        {
            return await _db.Service.ToListAsync();

        }

        public async Task<Service> Add(Service newService)
        {
            var dbService = new Service()
            {
                Id = newService.Id,
                Title = newService.Title,
                Price = newService.Price
            };

            await _db.Service.AddAsync(dbService);
            await _db.SaveChangesAsync();
            return dbService;
        }

        public async Task<Service?> Get(int id)
        {
            return await _db.Service.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Service?> Update(Service service)
        {
            var dbService = await Get(service.Id);
            if (dbService != null)
            {
                dbService.Title = service.Title;
                dbService.Price = service.Price;

                await _db.SaveChangesAsync();
                return dbService;
            }
            else
            {
                return null;
            }
        }

        public async Task<Service?> Delete(int id)
        {
            var dbService = await Get(id);

            if (dbService != null)
            {
                _db.Service.Remove(dbService);
                await _db.SaveChangesAsync();
                return dbService;
            }
            else
            {
                return null;
            }
        }
    }
}
