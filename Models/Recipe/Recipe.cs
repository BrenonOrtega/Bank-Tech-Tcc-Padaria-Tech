using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PadariaTech.Models.Base;

namespace PadariaTech.Models
{
    public class Recipe : EntityBase
    {

        public double Portion { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public BakedProduct BakedProduct { get; set; }

        public string pegarPorcao ()
        {
            return $"{ Portion } { BakedProduct.Measure }";
        }
    }
}