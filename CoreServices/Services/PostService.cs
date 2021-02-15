using CoreServices.Models;
using CoreServices.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class PostService : IPostService
    {
        BlogDBContext db;
        public PostService(BlogDBContext _db)
        {
            db = _db;
        }

        public async Task<List<Category>> GetCategories()
        {
            if (db != null)
            {
                return await db.Categories.ToListAsync();
            }

            return null;
        }

        public async Task<List<PostViewModel>> GetPosts()
        {
            if (db != null)
            {
                return await (from p in db.Posts
                              from c in db.Categories
                              where p.CategoryId == c.Id
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  CategoryName = c.Name,
                                  CreatedDate = p.CreatedDate
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<PostViewModel> GetPost(int? postId)
        {
            if (db != null)
            {
                return await (from p in db.Posts
                              from c in db.Categories
                              where p.PostId == postId
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  Description = p.Description,
                                  CategoryId = p.CategoryId,
                                  CategoryName = c.Name,
                                  CreatedDate = p.CreatedDate
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddPost(Post post)
        {
            if (db != null)
            {
                await db.Posts.AddAsync(post);
                await db.SaveChangesAsync();

                return post.PostId;
            }

            return 0;
        }

        public async Task<int> DeletePost(int? postId)
        {
            int result = 0;

            if (db != null)
            {
                var post = await db.Posts.FirstOrDefaultAsync(x => x.PostId == postId);

                if (post != null)
                {
                    db.Posts.Remove(post);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }


        public async Task UpdatePost(Post post)
        {
            if (db != null)
            {
                db.Posts.Update(post);
                
                await db.SaveChangesAsync();
            }
        }
    }
}