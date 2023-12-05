using Skladala.Persistence.Models;
using Skladala.Persistence.Repository.Interfaces;


namespace Skladala.App.Services
{
    public class ProductServices
    {
        private readonly IRepository<AllProductDto> _productRepository;

        public ProductServices(IRepository<AllProductDto> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<AllProductDto>> GetAsync()
        {
            try
            {
                var allProduct = await _productRepository.GetAsync(default);
                foreach (var item in allProduct)
                {
                    if((item.ExpirationDate - DateTime.Now).TotalHours <= ((item.ExpirationDate - item.DateManufacture).TotalHours * 0.2))
                    {
                        item.Cost -= item.Cost * 0.5;
                        await UpdateAsync(item);
                    }
                }
                return allProduct;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var exitingsDriver = await _productRepository.GetAsync(id, default);
            if (exitingsDriver is null)
            {
                return false;
            }
            await _productRepository.DeleteAsync(id, default);
            return true;
        }
        public async Task<bool> UpdateAsync(AllProductDto productDto)
        {
            var exitingsDriver = await _productRepository.GetAsync(productDto.Id, default);
            if (exitingsDriver is null)
            {
                return false;
            }
            await _productRepository.UpdateAsync(productDto);
            return true;
        }
    }
}
