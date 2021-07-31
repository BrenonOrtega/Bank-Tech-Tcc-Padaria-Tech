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
            var products = _service.GetAll();

            if (products.Any())
            {
                return Ok(products);
            }

            return NoContent();
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

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto dto)
        {
            try
            {
                var id = await _service.Register(dto);
                await _service.CommitChangesAsync();
                return CreatedAtAction(nameof(Get), new { id }, new { id, dto.Name, dto.Price, dto.Type });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
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

        [HttpDelete("{id}")]
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

        [HttpPatch("{id}/[Action]")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Sell(int id, [FromBody] ProductSellOrderCreateDto sellOrder)
        {
            try
            {
                var product = await _service.GetById(id);

                if (product is not null)
                {
                    var (sellValue, dto) = await _service.SellProduct(id, sellOrder.Quantity);

                    return Accepted(new { sellValue, sellOrder.Quantity, productId = dto.Id, productName = dto.Name, dto.Price });
                }

                return NotFound(new {Message = $"Id {id} Not Found"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }
    }
}