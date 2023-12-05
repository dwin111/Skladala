using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladala.Persistence.Models
{
    public class FoodProductDto: ProductDto
    {
        public double Weight { get; set; }
        public DateTime DateManufacture { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
