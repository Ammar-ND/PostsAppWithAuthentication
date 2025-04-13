using WebApplicationTest.Application_Layer.DTO;

namespace WebApplicationTest.Application_Layer.Interfaces
{
    public interface IPostService
    {
        Task<List<PostsDto>> getAllPosts();
        Task<PostsDto> AddPost(PostsDto PostDto);
        Task<bool> DeletePost(int Id);
        Task<bool> UpdatePost(int id, PostsDto PostDto);
    }
}
