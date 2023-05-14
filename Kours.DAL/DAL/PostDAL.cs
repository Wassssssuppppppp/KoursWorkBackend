using Kours.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kours.DAL.DAL
{
    public class PostDAL
    {
        private readonly MVCFlowersDbContext _db;

        public PostDAL(DbContextOptions<MVCFlowersDbContext> db)
        {
            _db = new MVCFlowersDbContext(db);
        }

        public async Task<List<Post>> GetAll()
        {
            return await _db.Post.ToListAsync();

        }

        public async Task<Post> Add(Post newPost)
        {
            var dbPost = new Post()
            {
                Id = newPost.Id,
                TitleOfThePosition = newPost.TitleOfThePosition
            };

            await _db.Post.AddAsync(dbPost);
            await _db.SaveChangesAsync();
            return dbPost;
        }

        public async Task<Post?> Get(int id)
        {
            return await _db.Post.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post?> Update(Post post)
        {
            var dbPost = await Get(post.Id);
            if (dbPost != null)
            {
                dbPost.TitleOfThePosition = post.TitleOfThePosition;

                await _db.SaveChangesAsync();
                return dbPost;
            }
            else
            {
                return null;
            }
        }

        public async Task<Post?> Delete(int id)
        {
            var dbPost = await Get(id);

            if (dbPost != null)
            {
                _db.Post.Remove(dbPost);
                await _db.SaveChangesAsync();
                return dbPost;
            }
            else
            {
                return null;
            }
        }
    }
}
