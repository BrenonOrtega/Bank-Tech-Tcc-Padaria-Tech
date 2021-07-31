using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PadariaTech.Domain.Models;

namespace PadariaTech.Data.Repository
{
    public class SellRepository : BaseRepository<Sell>, ISellRepository
    {
        public SellRepository(BakeryContext context) : base(context)
        {
        }
    }
}
