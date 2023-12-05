using Skladala.Core.Interfaces;
using System;

namespace Skladala.Core.Models
{
    public class FoodProduct : Product
    {
        public double Weight { get; set; }
        public DateTime DateManufacture { get; set; }
        public DateTime ExpirationDate { get; set; }


    }
}
