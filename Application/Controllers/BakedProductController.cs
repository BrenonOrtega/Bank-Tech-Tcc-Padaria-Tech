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

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post([FromBody]BakedProductCreateDto dto)
        {
            _service.Register(dto);
            await _service.CommitChangesAsync();

            return CreatedAtAction(nameof(Post),  dto);
        }


    }
}