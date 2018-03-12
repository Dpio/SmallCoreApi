using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Store.Logic;
using Store.Models.Products;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : CrudBaseController<ProductDto, CreateProductDto, ProductDto>
    {
        private readonly IProductService _service;

        public ProductController(IProductService service) : base(service)
        {
            _service = service;
        }

        [HttpGet("getActive")]
        [Produces("application/json", Type = typeof(IEnumerable<ProductDto>))]
        public IActionResult GetActive(GetActiveProductInput input)
        {
            var dto = _service.GetAllActive(input);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpGet("getAll")]
        [Produces("application/json", Type = typeof(IEnumerable<ProductDto>))]
        public IActionResult GetActive(GetAllProductsInput input)
        {
            var dto = _service.GetAll(input);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpGet("details/{id}")]
        [Produces("application/json", Type = typeof(ProductDetailsDto))]
        public IActionResult GetDetails(int id)
        {
            var dto = _service.GetWithDetails(id);
            if (dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }
    }
}