using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos.postDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCommunity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
           var posts = await _postService.GetAllAsync();
            return Ok(posts);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if(post == null) 
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("search/title")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
          var posts = await _postService.SearchByTitleAsync(title);
            return Ok(posts);
        }

        [HttpGet("search/category")]
        public async Task<IActionResult> SearchByCategory(int categoryId)
        {
            var posts = await _postService.SearchByCategoryAsync(categoryId);
            return Ok(posts);
        }
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePostDto dto,
            [FromQuery] int userId)
        {
            var post = new Post
            {
                Title = dto.Title,
                Text = dto.Text,
                CategoryID = dto.CategoryID
            };
            var result = await _postService.CreateAsync(post, userId);

            return result switch
            {
                CreatePostResult.Success =>
                    Ok(new { postId = post.PostID }),

                CreatePostResult.UserNotFound =>
                    Unauthorized("User not logged in"),

                CreatePostResult.CategoryNotFound =>
                    BadRequest("Invalid category"),

                _ => BadRequest()
            };
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdatePostDto dto,
            [FromQuery] int userId)
        {
            var success = await _postService.UpdateAsync(id, dto, userId);
            if (!success)
                return Unauthorized("You can only update your own posts");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromQuery] int userId)
        {
            var success = await _postService.DeleteAsync(id, userId);
            if (!success)
                return Unauthorized();

            return NoContent();
        }
    }
}
