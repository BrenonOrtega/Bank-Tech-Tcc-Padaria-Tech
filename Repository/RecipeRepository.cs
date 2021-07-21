using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(BakeryContext context) : base(context)
        {
        }
    }
}