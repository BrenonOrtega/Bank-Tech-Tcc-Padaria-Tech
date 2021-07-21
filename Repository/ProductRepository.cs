
using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(BakeryContext context) : base(context)
        {
        }
    }
}