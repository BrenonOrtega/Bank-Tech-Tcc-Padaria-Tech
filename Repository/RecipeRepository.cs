using Microsoft.EntityFrameworkCore;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext context) : base(context)
        {
        }
    }
}