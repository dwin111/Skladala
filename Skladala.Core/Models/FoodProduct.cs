using Skladala.Core.Interfaces;
using System;

namespace Skladala.Core.Models
{
    public class FoodProduct : Product, IProduct
    {
        public double Weight { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
