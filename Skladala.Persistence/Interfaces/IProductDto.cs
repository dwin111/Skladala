using Skladala.Core.Interfaces;
using System;

namespace Skladala.Persistence.Interfaces
{
    public interface IProductDto: IProduct
    {
        public string? Id { get; set; }
        public bool IsFoodProduct { get; set; }
    }
}
