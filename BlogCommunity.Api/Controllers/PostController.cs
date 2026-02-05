using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos.postDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        // -------------------- GET ALL POSTS --------------------

        [HttpGet]
        #region Doc
        [SwaggerOperation(
            Summary = "Get all posts",
            Description = "Returns a list of all blog posts"
        )]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        #endregion
        public async Task<IActionResult> GetAll() 
        {
           var posts = await _postService.GetAllAsync();
            return Ok(posts);

        }

        // -------------------- GET POST BY ID --------------------

        [HttpGet("{id}")]
        #region Doc
        [SwaggerOperation(
            Summary = "Get post by id",
            Description = "Returns a single blog post by id"
        )]
        [ProducesResponseType(typeof(Post), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        #endregion
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _postService.GetByIdAsync(id);
            if(post == null) 
            {
                return NotFound();
            }
            return Ok(post);
        }

        // -------------------- SEARCH BY TITLE --------------------


        [HttpGet("search/title")]
        #region Doc
        [SwaggerOperation(
            Summary = "Search posts by title",
            Description = "Returns all posts that contain the given title"
        )]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        #endregion
        public async Task<IActionResult> SearchByTitle(string title)
        {
          var posts = await _postService.SearchByTitleAsync(title);
            return Ok(posts);
        }

        // -------------------- SEARCH BY CATEGORY --------------------

        [HttpGet("search/category")]
        #region Doc
        [SwaggerOperation(
            Summary = "Search posts by category",
            Description = "Returns all posts for a specific category id"
        )]
        [ProducesResponseType(typeof(List<Post>), StatusCodes.Status200OK)]
        #endregion
        public async Task<IActionResult> SearchByCategory(int categoryId)
        {
            var posts = await _postService.SearchByCategoryAsync(categoryId);
            return Ok(posts);
        }

        // -------------------- CREATE POST --------------------

        [HttpPost]
        #region Doc
        [SwaggerOperation(
            Summary = "Create a new post",
            Description = "Creates a new blog post for a logged in user"
        )]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        #endregion
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

        // -------------------- UPDATE POST --------------------


        [HttpPut("{id}")]
        #region Doc
        [SwaggerOperation(
            Summary = "Update post",
            Description = "Updates an existing post. Only the owner can update the post"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        #endregion
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

        // -------------------- DELETE POST --------------------

        [HttpDelete("{id}")]
        #region Doc
        [SwaggerOperation(
            Summary = "Delete post",
            Description = "Deletes a post. Only the owner can delete the post"
        )]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        #endregion

        public async Task<IActionResult> Delete(int id, [FromQuery] int userId)
        {
            var success = await _postService.DeleteAsync(id, userId);
            if (!success)
                return Unauthorized();

            return NoContent();
        }
    }
}
