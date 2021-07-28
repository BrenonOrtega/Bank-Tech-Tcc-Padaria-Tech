using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Domain.Models;

namespace PadariaTech.Data.Repository
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(BakeryContext context) : base(context)
        {
        }
    }
}