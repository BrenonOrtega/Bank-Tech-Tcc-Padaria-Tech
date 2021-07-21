using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Models;

namespace PadariaTech.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BakedProductController : ControllerBase
    {
        private readonly IBakedProductRepository _repository;
        public BakedProductController(IBakedProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            return Ok(_repository.Get(x => true));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]BakedProduct bakedProduct)
        {
            _repository.Add(bakedProduct);
            await _repository.SaveChanges();
            return CreatedAtAction(nameof(Post), new { bakedProduct.Id }, bakedProduct);
        }
    }
}