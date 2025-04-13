using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using WebApplicationTest.Application_Layer.DTO;
using WebApplicationTest.Application_Layer.Interfaces;
using WebApplicationTest.Domain_Layer.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationTest.presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService, ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
        }



        /// <summary>
        /// Get all posts.
        /// </summary>
        /// <returns>A list of all posts.</returns>
        [AllowAnonymous]
        [HttpGet("getAllPosts")]
        public async Task<ActionResult<List<PostsDto>>> getAllPosts()
        {
            _logger.LogInformation("Received request to get all posts");
            var posts = await _postService.getAllPosts();
            _logger.LogInformation($"Retrieved {posts.Count} posts");
            return Ok(posts);
        }

        /// <summary>
        /// Create a new post.
        /// </summary>
        /// <param name="postDto">The data for the new post.</param>
        /// <returns>The created post.</returns>
        [HttpPost("AddPost")]
        public async Task<ActionResult<PostsDto>> AddPost([FromBody] PostsDto postDto)
        {

            var postdto = await _postService.AddPost(postDto);

            return Ok(postdto);
        }

        /// <summary>
        /// Delete a post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <returns>No content if deletion was successful, or NotFound if the post does not exist.</returns>
        [HttpDelete("DeletePost/{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            var Deleted = await _postService.DeletePost(id);
            if (!Deleted)
                return NotFound();
            return NoContent();
        }

        /// <summary>
        /// Update an existing post by its ID.
        /// </summary>
        /// <param name="id">The ID of the post to update.</param>
        /// <param name="postDto">Updated post data.</param>
        /// <returns>No content if update was successful, or NotFound if the post does not exist.</returns>
        [HttpPut("UpdatePost/{id}")]
        public async Task<ActionResult<PostsDto>> UpdatePost(int id, [FromBody] PostsDto postDto)
        {
            var updated = await _postService.UpdatePost(id, postDto);

            if (!updated)
                return NotFound();

            return NoContent(); // 204

        }
    }
}

/*             /// <summary>
               /// Get a post by its ID.
               /// </summary>
               /// <param name="id">The ID of the post to retrieve.</param>
               /// <returns>The requested post, or NotFound if the post does not exist.</returns>
               [HttpGet("{id}")]
               public async Task<ActionResult<PostsDto>> GetPost(int id) {
                   var post= await _postService.GetPost(id);
                   if (post == null) { 
                   return NotFound();
                   }
                   return Ok(post);

               }
       */