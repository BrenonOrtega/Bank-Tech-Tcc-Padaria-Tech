using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using PadariaTech.Services;
using PadariaTech.Dtos.Create;

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
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            var ingredients = _service.GetAll();

            if (ingredients.Any())
            {
                return Ok(ingredients);
            }

            return BadRequest();
        }
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get(int id)
        {
            var ingredient = _service.GetById(id);

            if (ingredient is not null)
            {
                return Ok(ingredient);
            }

            return BadRequest();
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] IngredientCreateDto dto)
        {
            var id = _service.Register(dto);
            await _service.CommitChangesAsync();

            return CreatedAtAction(nameof(Post), new { id }, new { id, dto.Name, dto.Quantity, dto.Measurement });
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

            _service.Update(ingredient.Id, dto);
            await _service.CommitChangesAsync();

            return Ok(ingredient);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var ingredient = _service.GetById(id);

            if (ingredient is null)
            {
                return BadRequest(ingredient);
            }

            _service.Delete(id);
            await _service.CommitChangesAsync();

            return NoContent();
        }
    }
}