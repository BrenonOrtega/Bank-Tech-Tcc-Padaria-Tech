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
    }
}