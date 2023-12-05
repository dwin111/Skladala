using Skladala.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladala.Persistence.Models
{
    public class NonfoodProductsDto: ProductDto
    {
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
