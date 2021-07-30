using System.Net;
using System.Linq;
using System.Threading.Tasks;
using PadariaTech.Application.Dtos.Create;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PadariaTech.Application.Controllers
{
    public partial class RecipeController
    {

        [HttpGet("{id}/[Action]")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Ingredients(int id)
        {
            var ingredients = _ingredientService.GetByRecipe(id);

            if (ingredients.Any())
            {
                return Ok(ingredients);
            }

            return NoContent();
        }

        [HttpGet("{id}/[Action]/{ingredientId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Ingredients(int id, int ingredientId)
        {
            var ingredient = await _ingredientService.GetById(id);

            if (ingredient is not null)
            {
                return Ok(ingredient);
            }

            return NoContent();
        }

        [HttpPost("{id}/[Action]")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Ingredients(int id, [FromBody] IngredientCreateDto dto)
        {
            try
            {
                dto.RecipeId = id;
                var ingredientId = await _ingredientService.Register(dto);
                return CreatedAtAction(nameof(Ingredients), new { id, ingredientId }, new { id = ingredientId, dto.Name, dto.Quantity, dto.Measurement });

            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.GetType().ToString(), Message = ex.Message });
            }
        }

        [HttpPut("{id}/[Action]/{ingredientId}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Ingredients(int id, int ingredientId, [FromBody] IngredientCreateDto dto)
        {
            var ingredient = await _ingredientService.GetById(ingredientId);
            if (ingredient is null)
            {
                return NotFound(ingredient);
            }

            await _ingredientService.Update(id, dto);

            return Accepted(ingredient);
        }

        [HttpDelete("{id}/Ingredients/{ingredientId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id, int ingredientId)
        {
            var ingredient = await _ingredientService.GetById(ingredientId);

            if (ingredient is null)
            {
                return NotFound();
            }
            _ingredientService.Delete(id);
            await _ingredientService.CommitChangesAsync();

            return NoContent();
        }
    }
}