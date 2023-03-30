using BLL.Abstractions;
using DTO.CategoryDTO.Create;
using DTO.CategoryDTO.Update;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;


        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.GetAllCategories();
            if (!result.IsError)
            {
                return Ok(result.Categories);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        [HttpGet("{page}/{limit}")]
        public async Task<IActionResult> GetPagination(int page, int limit)
        {
            var result = await _categoryService.GetCategoriesPagination(page, limit);
            if (!result.IsError)
            {
                return Ok(result.Categories);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.GetCategory(id);
            if (!result.IsError)
            {
                if (result.Category is null)
                {
                    return NotFound();
                }
                return Ok(result.Category);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryRequest category)
        {
            var result = await _categoryService.AddCategory(category);
            if (!result.IsError)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateCategoryRequest category)
        {
            var result = await _categoryService.UpdateCategory(id, category);
            if (!result.IsError)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            if (result.ErrorMessage == "Not found")
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategory(id);
            if (!result.IsError)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            if (result.ErrorMessage == "Not found")
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }
    }
}
