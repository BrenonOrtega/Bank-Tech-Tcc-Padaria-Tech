using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using PadariaTech.Domain.Enum;
using PadariaTech.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace PadariaTech.Domain.Models
{
    public partial class Product : EntityBase
    {
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public double StockQuantity { get; set; }

        [MaxLength(30)]
        public string Measure { get; set; }

        public ProductTypes Type { get; set; }

        public void AddQuantity(double quantity)
        {
            if (ValidQuantity(quantity))
            {
                StockQuantity += quantity;
            }
        }

        public void RemoveQuantity(double quantity)
        {
            if (IsDecreasePossible(quantity))
            {
                StockQuantity -= quantity;
            }
            else 
            {
                throw new InvalidOperationException("Stock does not have these much products.");
            }
        }

        private bool ValidQuantity(double quantity)
        {
            bool invalid = quantity <= 0;

            if (invalid)
            {
                throw new ArgumentException("Quantity must be a positive Number");
            }
            return true;
        }

        private bool IsDecreasePossible(double quantity) => 
            ValidQuantity(quantity) && quantity <= StockQuantity;

        public decimal GetSellValue(double quantity) => 
            Price * Convert.ToDecimal(quantity);

        public override string ToString() =>
            $"Product { Id } - { Name } - { Price } - { StockQuantity } { Measure }";
    }
}
