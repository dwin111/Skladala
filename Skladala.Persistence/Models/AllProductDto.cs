using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladala.Persistence.Models
{
    public class AllProductDto: ProductDto
    {
        public double Weight { get; set; }
        public DateTime DateManufacture { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
