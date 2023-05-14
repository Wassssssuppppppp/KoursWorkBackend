using Kours.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL.DAL
{
    public class SkladDAL
    {
        private readonly MVCFlowersDbContext _db;

        public SkladDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Sklad>> GetAll()
        {
            return await _db.Sklad.ToListAsync();

        }

        public async Task<Sklad> Add(Sklad newSklad)
        {
            var dbSklad = new Sklad()
            {
                Id = newSklad.Id,
                Title = newSklad.Title,
                quantity = newSklad.quantity
            };

            await _db.Sklad.AddAsync(dbSklad);
            await _db.SaveChangesAsync();
            return dbSklad;
        }

        public async Task<Sklad?> Get(int id)
        {
            return await _db.Sklad.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Sklad?> Update(Sklad sklad)
        {
            var dbSklad = await Get(sklad.Id);
            if (dbSklad != null)
            {
                dbSklad.Title = sklad.Title;
                dbSklad.quantity = sklad.quantity;

                await _db.SaveChangesAsync();
                return dbSklad;
            }
            else
            {
                return null;
            }
        }

        public async Task<Sklad?> Delete(int id)
        {
            var dbSklad = await Get(id);

            if (dbSklad != null)
            {
                _db.Sklad.Remove(dbSklad);
                await _db.SaveChangesAsync();
                return dbSklad;
            }
            else
            {
                return null;
            }
        }
    }
}
