
namespace Skladala.Persistence.Models
{
    public class FoodProductDto: ProductDto
    {
        public double Weight { get; set; }
        public DateTime DateManufacture { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
