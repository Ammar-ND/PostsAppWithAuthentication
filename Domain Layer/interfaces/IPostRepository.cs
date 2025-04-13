using WebApplicationTest.Domain_Layer.Entities;

namespace WebApplicationTest.Domain_Layer.interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> getAllPosts();
        Task<Post> AddPost(Post post);
        Task <bool>DeletePost(int id);
        Task <bool> UpdatePost(int id, Post post);
    }
}
