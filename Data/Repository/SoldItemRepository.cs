using Microsoft.EntityFrameworkCore;
using PadariaTech.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadariaTech.Data.Repository
{
    public class SoldItemRepository : BaseRepository<SoldItem>, ISoldItemRepository
    {
        public SoldItemRepository(BakeryContext context) : base(context)
        {
        }
    }
}
