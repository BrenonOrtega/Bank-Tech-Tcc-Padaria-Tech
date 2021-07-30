using System;
using System.Net;
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
        public async Task<IActionResult> Get()
        {
            var mappedBakedProducts = _service.GetAll();

            return Ok(mappedBakedProducts);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            var bakedProduct =  _service.GetById(id);

            if(bakedProduct.IsEmpty)
            {
                return NotFound();
            }

            return Ok(bakedProduct);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]BakedProductCreateDto dto)
        {
            try 
            {
                var id = await _service.Register(dto);
    
                return CreatedAtAction(nameof(Get), new { id },  new { id, dto.Name });
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
    }
}