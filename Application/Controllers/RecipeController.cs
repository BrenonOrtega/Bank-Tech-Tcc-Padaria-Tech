using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PadariaTech.Application.Dtos.Create;
using PadariaTech.Domain.Models;
using PadariaTech.Services;

namespace TccPadariaTech.Application.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _service;

        public RecipeController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
         public async Task<IActionResult> Get()
        {
            var recipes = _service.GetAll();
            
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
            await _service.CommitChangesAsync();
            return CreatedAtAction(nameof(Post), new { recipe.Name }, recipe);
        }
    }
}