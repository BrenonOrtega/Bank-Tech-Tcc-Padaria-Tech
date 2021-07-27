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
        public IActionResult GetAll()
        {
            var ingredients = _ingredientService.GetAll();

            if (ingredients.Any()) return Ok(ingredients);

            return NoContent();
        }
        [HttpGet]
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            var ingredient = _ingredientService.GetById(id);

            if(ingredient is not null) return Ok(ingredient);

            return NotFound();
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
        [Route("/{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = _ingredientService.GetById(id);

            if(ingredient is null) return NotFound();

            _ingredientService.Delete(id);
            await _ingredientService.CommitChangesAsync();

            return NoContent();
        }
        [HttpPut]
        [Route("{/id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(int id, [FromBody] IngredientCreateDto ingredientDto)
        {
            var ingredient = _ingredientService.GetById(id);

            if(ingredient is null) return NotFound();

            _ingredientService.Update(id, ingredientDto);
            await _ingredientService.CommitChangesAsync();

            return Ok();
        }
    }
}