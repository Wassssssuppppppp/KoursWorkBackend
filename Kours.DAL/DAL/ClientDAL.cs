using Kours.Domain;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL.DAL
{
    public class ClientDAL
    {
        private readonly MVCFlowersDbContext _db;

        public ClientDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _db.Client.ToListAsync();
        }

        public async Task<Client> Add(Client newClient)
        {
            var client = new Client()
            {
                Id = newClient.Id,
                Surname = newClient.Surname,
                Name = newClient.Name,
                Middle_name = newClient.Middle_name,
                Phone = newClient.Phone,
                Address = newClient.Address
            };

            await _db.Client.AddAsync(client);
            await _db.SaveChangesAsync();
            return client;
        }

        public async Task<Client?> Get(int id)
        {
            return await _db.Client.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client?> Update(Client client)
        {
            var dbClient = await Get(client.Id);
            if (dbClient != null)
            {
                dbClient.Surname = client.Surname;
                dbClient.Name = client.Name;
                dbClient.Middle_name = client.Middle_name;
                dbClient.Phone = client.Phone;
                dbClient.Address = client.Address;

                await _db.SaveChangesAsync();
                return dbClient;
            }
            else
            {
                return null;
            }
        }

        public async Task<Client?> Delete(int id)
        {
            var dbClient = await Get(id);

            if (dbClient != null)
            {
                _db.Client.Remove(dbClient);
                await _db.SaveChangesAsync();
                return dbClient;
            }
            else
            {
                return null;
            }
        }
    }
}
