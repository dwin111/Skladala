using Skladala.Persistence.Models;
using Skladala.Persistence.Repository.Interfaces;

namespace Skladala.App.Services
{
    public class NonfoodProductServices
    {
        private readonly IRepository<NonfoodProductsDto> _nonFoodProductRepository;
        private readonly ProductServices _productServices;

        public NonfoodProductServices(IRepository<NonfoodProductsDto> foodProductRepository, ProductServices productServices)
        {
            _nonFoodProductRepository = foodProductRepository;
            _productServices = productServices;
        }

        public async Task<IEnumerable<NonfoodProductsDto>> GetAsync()
        {
            try
            {
                List<NonfoodProductsDto> nonfoogProduct = new List<NonfoodProductsDto>();
                var products = await _productServices.GetAsync();
                foreach (var foodProduct in products.Where(p => p.IsFoodProduct == false))
                {
                    nonfoogProduct.Add(new NonfoodProductsDto()
                    {
                        Id = foodProduct.Id,
                        Name = foodProduct.Name,
                        Quantity = foodProduct.Quantity,
                        Group = foodProduct.Group,
                        IsFoodProduct = foodProduct.IsFoodProduct,
                        Manufacturer = foodProduct.Manufacturer,
                        Cost = foodProduct.Cost,
                        ChangedPrice = foodProduct.ChangedPrice,
                        Height = foodProduct.Height,
                        Width = foodProduct.Width,
                    });
                }
                return nonfoogProduct;

            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateAsync(NonfoodProductsDto model)
        {
            try
            {
                await _nonFoodProductRepository.CreateAsync(model);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
