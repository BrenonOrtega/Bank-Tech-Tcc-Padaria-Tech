using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Services;
using PadariaTech.Dtos.Create;

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
        public IActionResult Post([FromBody] IngredientCreateDto ingredientDto)
        {

        }

    }
}