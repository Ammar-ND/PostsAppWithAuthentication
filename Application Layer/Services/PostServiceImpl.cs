using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplicationTest.Application_Layer.DTO;
using WebApplicationTest.Application_Layer.Interfaces;
using WebApplicationTest.Application_Layer.Services;
using WebApplicationTest.Domain_Layer.Entities;
using WebApplicationTest.Domain_Layer.interfaces;
using WebApplicationTest.Infrastructure_Layer.Data;
using WebApplicationTest.Infrastructure_Layer.Repositories;

namespace WebApplicationTest.Application_Layer.Services
{


    public class PostServiceImpl : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ILogger<PostServiceImpl> _logger;


        public PostServiceImpl(IPostRepository postRepository, ILogger<PostServiceImpl> logger)
        {
            _postRepository = postRepository;
            _logger = logger;
        }

        public async Task<List<PostsDto>> getAllPosts()
        {
            _logger.LogInformation("Fetching all posts...");

            var posts = await _postRepository.getAllPosts();

            _logger.LogInformation("Fetched {Count} posts", posts.Count);

            var result = new List<PostsDto>();
            foreach (var post in posts)
            {
                result.Add(new PostsDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Body = post.Body,
                });
            }
            return result;
        }

        public async Task<PostsDto> AddPost(PostsDto postsDto)
        {
            _logger.LogInformation("Starting AddPost with name: {Name}", postsDto.Body);
            var post = new Post
            {
                Title = postsDto.Title,
                Body = postsDto.Body,
            };

                var Result = await _postRepository.AddPost(post);

                _logger.LogInformation("Post added successfully with id: {Id}", Result.Id);

                return new PostsDto
                {
                    Id = Result.Id,
                    Title = Result.Title,
                    Body = Result.Body
                };
        }

        public async Task<bool> DeletePost(int Id)
        {
            _logger.LogInformation("Attempting to delete post with ID: {Id}", Id);

            var deleted = await _postRepository.DeletePost(Id);

            if (!deleted)
            {
                _logger.LogWarning("Delete failed. Post with ID: {Id} not found", Id);
                return false;
            }

            _logger.LogInformation("Post with ID: {Id} deleted successfully", Id);
            return true;
        }





        public async Task<bool> UpdatePost(int id, PostsDto PostDto)
        {
            _logger.LogInformation("Attempting to update post with ID: {Id}", id);

            var post = new Post
            {
                Id=id,
                Title = PostDto.Title,
                Body = PostDto.Body
            };

            var updated = await _postRepository.UpdatePost(id, post);

            if (!updated)
            {
                _logger.LogWarning("Update failed. Post with ID: {Id} not found", id);
                return false;
            }

            _logger.LogInformation("Post with ID: {Id} updated successfully", id);
            return true;
        }




        /*
        public async Task<List<PostsDto>> GetPosts()
        {
            var posts = await _postRepository.GetPosts();


            return posts.Select(x => new PostsDto
            {
                Name = x.Name,
                Description = x.Description,
            }).ToList();

        }

        */





    }

}

