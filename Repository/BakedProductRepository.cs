using Microsoft.EntityFrameworkCore;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class BakedProductRepository : BaseRepository<BakedProduct>, IBakedProductRepository
    {
        public BakedProductRepository(DbContext context) : base(context)
        {
        }
    }
}