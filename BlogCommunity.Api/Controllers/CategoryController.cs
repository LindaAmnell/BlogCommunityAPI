using BlogCommunity.Api.Core.Interfaces;
using BlogCommunity.Api.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlogCommunity.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // -------------------- GET ALL CATEGORIES --------------------

        [HttpGet]
        #region Doc
        [SwaggerOperation(
            Summary = "Get all categories",
            Description = "Returns a list of all available post categories"
        )]
        [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)]
        #endregion
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        // -------------------- ADD CATEGORY --------------------

        [HttpPost]
        #region Doc
        [SwaggerOperation(
            Summary = "Create a new category",
            Description = "Creates a new category for blog posts"
        )]
        [ProducesResponseType(typeof(Category), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        #endregion
        public async Task<IActionResult> Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                return BadRequest("Category name is required");

            await _categoryService.AddCategoryAsync(category);

            return StatusCode(StatusCodes.Status201Created, category);
        }
    }
}
