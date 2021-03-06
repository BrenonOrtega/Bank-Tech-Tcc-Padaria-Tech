using System;
using System.Net;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Services;

namespace PadariaTech.Application.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BakedProductController : ControllerBase
    {
        private readonly BakedProductService _service;

        public BakedProductController(BakedProductService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var mappedBakedProducts = _service.GetAll();

            return Ok(mappedBakedProducts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var bakedProduct = await _service.GetById(id);

            if (bakedProduct.IsEmpty)
            {
                return NotFound();
            }

            return Ok(bakedProduct);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] BakedProductCreateDto dto)
        {
            try
            {
                var id = await _service.Register(dto);

                return CreatedAtAction(nameof(Get), new { id }, new { id, dto.Name });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] BakedProductCreateDto dto)
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

        [HttpPatch("{id}/Bake")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PatchQuantity(int id)
        {
            try
            {
                await _service.BakeProduct(id);
                return Accepted();
            }
            catch(KeyNotFoundException knfex)
            {
                return NotFound(new {ErrorMessage = knfex.Message });
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
