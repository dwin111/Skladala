
namespace Skladala.Core.Interfaces
{
    public interface IProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public double Cost { get; set; }
        public double ChangedPrice { get; set; }
        public string Group { get; set; }
    }
}
