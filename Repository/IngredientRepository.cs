using Microsoft.EntityFrameworkCore;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(DbContext context) : base(context)
        {
        }
    }
}