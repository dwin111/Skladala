using Skladala.Core.Interfaces;
using System;
namespace Skladala.Core.Models
{
    public class NonfoodProducts : Product, IProduct
    {
        public double Height { get; set; }
        public double Width { get; set; }
    }
}
