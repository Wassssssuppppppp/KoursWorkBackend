using Kours.Domain;
using Kours.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Kours.DAL
{
    public class MVCFlowersDbContext : DbContext
    {
        public MVCFlowersDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<StoreAddress> StoreAddress { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Sklad> Sklad { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Zakaz> Zakaz { get; set; }

    }
}
