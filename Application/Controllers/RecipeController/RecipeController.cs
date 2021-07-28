using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using PadariaTech.Application.Services;

namespace PadariaTech.Application.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public partial class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;        
        private readonly IngredientService _ingredientService;

        public RecipeController(RecipeService recipeService, IngredientService ingredientService)
        {
            _recipeService = recipeService;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
         public async Task<IActionResult> Get()
        {
            var recipes = _recipeService.GetAll();
            
            if(recipes.Any())
                return Ok(recipes);
            
            return NoContent();
        }   

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]RecipeCreateDto recipe)
        {
            var id = await _recipeService.Register(recipe);
            return CreatedAtAction(nameof(Post), new { recipe.Name }, recipe);
        }
    }
}