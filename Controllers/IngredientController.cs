using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Services;
using PadariaTech.Dtos.Create;
using System.Threading.Tasks;

namespace PadariaTech.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    class IngredientController : ControllerBase
    {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get()
        {
            var ingredients = _ingredientService.GetAll();

            if (ingredients.Any()) return Ok(ingredients);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] IngredientCreateDto ingredientDto)
        {
            var id = _ingredientService.Register(ingredientDto);
            await _ingredientService.CommitChangesAsync();

            return CreatedAtAction(nameof(Post), new { id }, new { id, ingredientDto.Name, ingredientDto.Measurement, ingredientDto.Quantity });
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = _ingredientService.GetById(id);

            if(ingredient is null) return NotFound();

            _ingredientService.Delete(id);
            await _ingredientService.CommitChangesAsync();

            return Ok();
        }
    }
}