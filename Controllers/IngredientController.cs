using Microsoft.AspNetCore.Mvc;
using PadariaTech.Services;

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
    }
}