using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PadariaTech.Application.Dtos.Create
{
    public class SellCreateDto
    {   
        DateTime SellDate { get; set; } = DateTime.UtcNow;
    }
}
