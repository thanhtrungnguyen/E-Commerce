using BLL.Abstractions;
using DAL.Enums;
using DTO.BrandDTO.Create;
using DTO.BrandDTO.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;


        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Get()
        {
            var result = await _brandService.GetAllBrands();
            if (!result.IsError)
            {
                return Ok(result.Brands);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        [HttpGet("{page}/{limit}")]
        public async Task<IActionResult> GetPagination(int page, int limit)
        {
            var result = await _brandService.GetBrandsPagination(page, limit);
            if (!result.IsError)
            {
                return Ok(result.Brands);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _brandService.GetBrand(id);
            if (!result.IsError)
            {
                if (result.Brand is null)
                {
                    return NotFound();
                }
                return Ok(result.Brand);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // POST api/<BrandsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBrandRequest brand)
        {
            var result = await _brandService.AddBrand(brand);
            if (!result.IsError)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, result.ErrorMessage);
        }

        // PUT api/<BrandsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateBrandRequest brand)
        {
            var result = await _brandService.UpdateBrand(id, brand);
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

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandService.DeleteBrand(id);
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
