using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Domain_Layer.Entities;
using WebApplicationTest.Domain_Layer.interfaces;
using WebApplicationTest.Infrastructure_Layer.Data;

namespace WebApplicationTest.Infrastructure_Layer.Repositories
{
    public class PostRepositoryImpl : IPostRepository
    {
        private readonly PostDbContext _dbContext;
        public PostRepositoryImpl(PostDbContext context) {
            _dbContext = context;
        }

        public async Task<List<Post>> getAllPosts()
        {
            return await _dbContext.Posts.ToListAsync();
        }
        public async Task<Post> AddPost(Post post)
        {
            await _dbContext.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<bool> DeletePost(int id)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }
            else { 
                _dbContext.Remove(post);
            await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> UpdatePost(int id, Post post)
        {
            var upPost = await _dbContext.Posts.FindAsync(id);
            if (upPost == null)
                return false;
            upPost.Title = post.Title;
            upPost.Body = post.Body;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
    
}
