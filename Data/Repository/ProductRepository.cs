
using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Domain.Models;

namespace PadariaTech.Data.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(BakeryContext context) : base(context)
        {
        }
        public override IQueryable<Product> Get(Expression<Func<Product, bool>> expression)
        {
            return base.Get(expression).Include(x => x.Ingredients);
        }

    }
}