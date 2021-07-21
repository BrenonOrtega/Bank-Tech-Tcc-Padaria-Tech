
using Microsoft.EntityFrameworkCore;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}