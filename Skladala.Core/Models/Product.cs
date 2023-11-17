namespace Skladala.Core.Models
{
    public abstract class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public double Сost { get; set; }
        public string Group { get; set; }
        public abstract void ValueValidation();

    }
}
