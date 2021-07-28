
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
    }
}