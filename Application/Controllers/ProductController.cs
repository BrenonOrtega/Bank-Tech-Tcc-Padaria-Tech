using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Application.Services;
using PadariaTech.Application.Dtos.Create;
using System;

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
            try
            {
                var id = await _service.Register(dto);
                await _service.CommitChangesAsync();
                return CreatedAtAction(nameof(Post), new { id }, new { id, dto.Name, dto.Price, dto.Type });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _service.GetById(id);

            if (product.IsEmpty)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] ProductCreateDto dto)
        {
            try
            {
                await _service.Update(id, dto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }

        [HttpDelete("/delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetById(id);

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