using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(BakeryContext context) : base(context)
        {
        }
    }
}