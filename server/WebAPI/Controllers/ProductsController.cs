using BLL.Abstractions;
using DTO.ProductDTO.Create;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productService.GetAllProducts();
            if (!result.IsError)
            {
                return Ok(result.products);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _productService.GetProduct(id);
            if (!result.IsError)
            {
                if (result.product is null)
                {
                    return NotFound();
                }
                return Ok(result.product);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductRequest createProductRequest)
        {
            var result = await _productService.AddProduct(createProductRequest);
            if (!result.IsError)
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] CreateProductRequest updateProductRequest)
        {
            var result = await _productService.GetProduct(id);
            if (!result.IsError)
            {
                if (result.product is null)
                {
                    return NotFound();
                }
                return Ok(result.product);
            }
            var result2 = await _productService.UpdateProduct(id, updateProductRequest);

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
