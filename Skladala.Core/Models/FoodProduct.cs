using System;

namespace Skladala.Core.Models
{
    public class FoodProduct : Product
    {
        public double Weight { get; set; }
        public DateTime ExpirationDate { get; set; }

        public override void ValueValidation()
        {
            throw new NotImplementedException();
        }
    }
}
