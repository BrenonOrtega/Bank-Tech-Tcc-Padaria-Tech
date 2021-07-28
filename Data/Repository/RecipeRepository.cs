using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Domain.Models;

namespace PadariaTech.Data.Repository
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(BakeryContext context) : base(context)
        {
        }
    }
}