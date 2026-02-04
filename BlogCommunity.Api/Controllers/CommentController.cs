using BlogCommunity.Api.Core.Enum;
using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using BlogCommunity.Api.Dtos.CommentDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogCommunity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(
           [FromQuery] int postId,
           [FromQuery] int userId,
           [FromBody] CreateCommentDto dto)
        {
            var result = await _commentService.AddCommentAsync(postId, dto, userId);

            return result switch
            {
                CreateCommentResult.Success =>
                    Ok(),

                CreateCommentResult.UserNotFound =>
                    Unauthorized("User not logged in"),

                CreateCommentResult.PostNotFound =>
                    BadRequest("Post not found"),

                CreateCommentResult.CannotCommentOwnPost =>
                    BadRequest("You cannot comment your own post"),

                _ => BadRequest()
            };
        }



    }
}
