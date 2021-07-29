using System;
using System.Linq;
using System.Linq.Expressions;
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
        public override IQueryable<Ingredient> Get(Expression<Func<Ingredient, bool>> expression)
        {
            return base.Get(expression).Include(x => x.Product).Include(x => x.Recipe);
        }
    }
}