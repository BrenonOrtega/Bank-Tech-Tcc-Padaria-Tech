using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Dtos.Create;
using PadariaTech.Models;
using PadariaTech.Services;

namespace TccPadariaTech.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _repository;
        private readonly RecipeService _service;

        public RecipeController(IRecipeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
         public async Task<IActionResult> Get()
        {
            var recipes = _repository.Get(x => true).ToList();
            
            if(recipes.Any())
                return Ok(recipes);
            
            return NoContent();
        }   

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]RecipeCreateDto recipe)
        {
            _service.Register(recipe);
            //_repository.Add(recipe);
            await _repository.SaveChanges();
            return CreatedAtAction(nameof(Post), new { recipe.Name }, recipe);
        }
    }
}