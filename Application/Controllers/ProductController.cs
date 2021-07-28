using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Application.Services;
using PadariaTech.Application.Dtos.Create;

namespace PadariaTech.Application.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get()
        {
            var bakedProducts = _service.GetAll();

            if (bakedProducts.Any())
            {
                return Ok(bakedProducts);
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto dto)
        {
            var id = _service.Register(dto);
            await _service.CommitChangesAsync();

            return CreatedAtAction(nameof(Post), new { id }, new { id, dto.Name, dto.Price, dto.ProductType });
        }

        [HttpPut("/delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = _service.GetById(id);

            if (product is null)
            {
                return NotFound(product);
            }

            _service.Delete(id);
            await _service.CommitChangesAsync();

            return NoContent();
        }
    }
}