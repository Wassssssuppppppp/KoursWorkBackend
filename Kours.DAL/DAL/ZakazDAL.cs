using Kours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{
    public class ZakazDAL
    {
        private readonly MVCFlowersDbContext _db;

        public ZakazDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Zakaz>> GetAll()
        {
            return await _db.Zakaz.ToListAsync();

        }

        public async Task<Zakaz> Add(Zakaz newZakaz)
        {
            var zakaz = new Zakaz()
            {
                Id = newZakaz.Id,
                ClientID = newZakaz.ClientID,
                ProductId = newZakaz.ProductId,
                EmployeeId = newZakaz.EmployeeId,
                ServiceId = newZakaz.ServiceId,
                StoreAddressesId = newZakaz.StoreAddressesId,
                Status = newZakaz.Status,
                OrderDate = DateTime.Now
            };

            await _db.Zakaz.AddAsync(zakaz);
            await _db.SaveChangesAsync();
            return zakaz;
        }

        public async Task<Zakaz?> Get(int id)
        {
            return await _db.Zakaz.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Zakaz?> Update(Zakaz model)
        {
            var dbZakaz = await Get(model.Id);
            if (dbZakaz != null)
            {
                dbZakaz.ClientID = model.ClientID;
                dbZakaz.ProductId = model.ProductId;
                dbZakaz.EmployeeId = model.EmployeeId;
                dbZakaz.ServiceId = model.ServiceId;
                dbZakaz.StoreAddressesId = model.StoreAddressesId;
                dbZakaz.Status = model.Status;
                dbZakaz.OrderDate = model.OrderDate;

                await _db.SaveChangesAsync();
                return dbZakaz;
            }
            else
            {
                return null;
            }
        }

        public async Task<Zakaz?> Delete(int id)
        {
            var dbZakaz = await Get(id);

            if (dbZakaz != null)
            {
                _db.Zakaz.Remove(dbZakaz);
                await _db.SaveChangesAsync();
                return dbZakaz;
            }
            else
            {
                return null;
            }
        }
    }
}
