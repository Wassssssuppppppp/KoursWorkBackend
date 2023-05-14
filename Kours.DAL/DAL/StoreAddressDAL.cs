using Kours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{
    public class StoreAddressDAL
    {
        private readonly MVCFlowersDbContext _db;

        public StoreAddressDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<StoreAddress>> GetAll()
        {
            return await _db.StoreAddress.ToListAsync();

        }

        public async Task<StoreAddress> Add(StoreAddress newStoreAddress)
        {
            var dbStoreAddress = new StoreAddress()
            {
                Id = newStoreAddress.Id,
                Store_address = newStoreAddress.Store_address
            };

            await _db.StoreAddress.AddAsync(dbStoreAddress);
            await _db.SaveChangesAsync();
            return dbStoreAddress;
        }

        public async Task<StoreAddress?> Get(int id)
        {
            return await _db.StoreAddress.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<StoreAddress?> Update(StoreAddress storeAddress)
        {
            var dbStoreAddress = await Get(storeAddress.Id);
            if (dbStoreAddress != null)
            {
                dbStoreAddress.Store_address = storeAddress.Store_address;

                await _db.SaveChangesAsync();
                return dbStoreAddress;
            }
            else
            {
                return null;
            }
        }

        public async Task<StoreAddress?> Delete(int id)
        {
            var dbStoreAddress = await Get(id);

            if (dbStoreAddress != null)
            {
                _db.StoreAddress.Remove(dbStoreAddress);
                await _db.SaveChangesAsync();
                return dbStoreAddress;
            }
            else
            {
                return null;
            }
        }
    }
}
