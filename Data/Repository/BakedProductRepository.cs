using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Domain.Models;

namespace PadariaTech.Data.Repository
{
    public class BakedProductRepository : BaseRepository<BakedProduct>, IBakedProductRepository
    {
        public BakedProductRepository(BakeryContext context) : base(context)
        {
        }
        public override IQueryable<BakedProduct> Get(Expression<Func<BakedProduct, bool>> expression)
        {
            return base.Get(expression)
                .Include(x => x.Recipe)
                .ThenInclude(r => r.Ingredients)
                .ThenInclude(i => i.Product);
        }
    }
}