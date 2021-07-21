using Microsoft.EntityFrameworkCore;
using PadariaTech.Data;
using PadariaTech.Models;

namespace PadariaTech.Repository
{
    public class BakedProductRepository : BaseRepository<BakedProduct>, IBakedProductRepository
    {
        public BakedProductRepository(BakeryContext context) : base(context)
        {
        }
    }
}