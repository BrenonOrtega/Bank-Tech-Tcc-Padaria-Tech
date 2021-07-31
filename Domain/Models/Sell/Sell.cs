using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PadariaTech.Domain.Models
{
    public class Sell : EntityBase
    {
        [DataType(DataType.DateTime)]
        public DateTime SellDate { get; set; } = DateTime.UtcNow;

        public ICollection<SoldItem> SoldItems { get; set; }

        public decimal TotalValue { get => SoldItems.Sum(soldItem => soldItem.Value); }

        public Sell()
        {
            SoldItems = new HashSet<SoldItem>();
        }
       
        public void AddItem(params SoldItem[] items)
        {
            if (items?.Length > 0)
            {
                SoldItems = SoldItems.Union(items).ToList();
            }
        }
    }
}
