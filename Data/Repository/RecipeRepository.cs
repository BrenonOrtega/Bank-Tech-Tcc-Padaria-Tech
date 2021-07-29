using System;
using System.Linq;
using System.Linq.Expressions;
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
        public override IQueryable<Recipe> Get(Expression<Func<Recipe, bool>> expression)
        {
            return base.Get(expression).Include(x => x.BakedProduct).Include(x => x.Ingredients);
        }
    }
}