using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Models;

namespace TccPadariaTech.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _repository;
        public IngredientController(IIngredientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get()
        {
            var bakedProducts = _repository.Get(x => true).ToList();

            if (bakedProducts.Any())
                return Ok(bakedProducts);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] Ingredient ingredient)
        {
            _repository.Add(ingredient);
            await _repository.SaveChanges();
            return CreatedAtAction(nameof(Post), new { ingredient.Id }, ingredient);
        }
    }
}