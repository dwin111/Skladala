
namespace Skladala.Core.Interfaces
{
    public interface IProduct
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public double Сost { get; set; }
        public string Group { get; set; }
    }
}
