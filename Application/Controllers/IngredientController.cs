using System.Net;
using System.Linq;
using System.Threading.Tasks;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace PadariaTech.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IngredientService _service;

        public IngredientController(IngredientService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get()
        {
            var ingredients = _service.GetAll();

            if (ingredients.Any())
            {
                return Ok(ingredients);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Get(int id)
        {
            var ingredient = _service.GetById(id);

            if (ingredient is not null)
            {
                return Ok(ingredient);
            }

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] IngredientCreateDto dto)
        {
            var id = _service.Register(dto);
            await _service.CommitChangesAsync();

            return CreatedAtAction(nameof(Get), new { id }, new { id, dto.Name, dto.Quantity, dto.Measurement, dto.IdRecipe });
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] IngredientCreateDto dto)
        {
            var ingredient = _service.GetById(id);
            if(ingredient is null) 
            {
                return BadRequest(ingredient);
            }

            _service.Update(id, dto);
            await _service.CommitChangesAsync();

            return Ok(ingredient);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = _service.GetById(id);

            if (ingredient is null)
            {
                return NotFound();
            }
            _service.Delete(id);
            await _service.CommitChangesAsync();

            return NoContent();
        }
    }
}