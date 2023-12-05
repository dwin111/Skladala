
using Skladala.Persistence.Models;
using Skladala.Persistence.Repository.Interfaces;

namespace Skladala.App.Services
{
    public class FoodProductServices
    {
        private readonly IRepository<FoodProductDto> _foodProductRepository;
        private readonly ProductServices _productServices;

        public FoodProductServices(IRepository<FoodProductDto> foodProductRepository, ProductServices productServices)
        {
            _foodProductRepository = foodProductRepository;
            _productServices = productServices;
        }



        public async Task<IEnumerable<FoodProductDto>> GetAsync()
        {
            try
            {
                List<FoodProductDto> foogProduct = new List<FoodProductDto>();
                var products = await _productServices.GetAsync();
                foreach (var foodProduct in products.Where(p => p.IsFoodProduct == true)) 
                {
                    foogProduct.Add(new FoodProductDto()
                    {
                        Id = foodProduct.Id,
                        Name = foodProduct.Name,
                        Quantity = foodProduct.Quantity,
                        ExpirationDate = foodProduct.ExpirationDate,
                        DateManufacture = foodProduct.DateManufacture,
                        Group = foodProduct.Group,
                        IsFoodProduct = foodProduct.IsFoodProduct,
                        Manufacturer = foodProduct.Manufacturer,
                        Weight = foodProduct.Weight,
                        Cost = foodProduct.Cost
                    }) ;
                }
                return foogProduct;
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateAsync(FoodProductDto model)
        {
            try
            {
                await _foodProductRepository.CreateAsync(model);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
