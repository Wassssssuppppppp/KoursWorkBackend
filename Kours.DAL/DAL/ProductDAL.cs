using Kours.Domain;
using Kours.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{
    public class ProductDAL
    {
        private readonly MVCFlowersDbContext _db;

        public ProductDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _db.Product.ToListAsync();

        }

        public async Task<Product> Add(Product newProduct)
        {
            var dbProduct = new Product()
            {
                Id = newProduct.Id,
                SkladId = newProduct.SkladId,
                Title = newProduct.Title,
                PricePerPiece = newProduct.PricePerPiece,
                ZakazOrderCode = newProduct.ZakazOrderCode
            };

            await _db.Product.AddAsync(dbProduct);
            await _db.SaveChangesAsync();
            return dbProduct;
        }

        public async Task<Product?> Get(int id)
        {
            return await _db.Product.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> Update(Product product)
        {
            var dbProduct = await Get(product.Id);
            if (dbProduct != null)
            {
                dbProduct.SkladId = product.SkladId;
                dbProduct.Title = product.Title;
                dbProduct.PricePerPiece = product.PricePerPiece;
                dbProduct.ZakazOrderCode = product.ZakazOrderCode;

                await _db.SaveChangesAsync();
                return dbProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product?> Delete(int id)
        {
            var dbProduct = await Get(id);

            if (dbProduct != null)
            {
                _db.Product.Remove(dbProduct);
                await _db.SaveChangesAsync();
                return dbProduct;
            }
            else
            {
                return null;
            }
        }
    }
}
