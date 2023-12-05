using Skladala.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skladala.Persistence.Interfaces
{
    public interface IProductDto: IProduct
    {
        public string? Id { get; set; }
        public bool IsFoodProduct { get; set; }
    }
}
