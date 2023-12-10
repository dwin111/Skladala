using Skladala.Persistence.Interfaces;
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
                    if(item.IsFoodProduct && item.ChangedPrice == 0 && (item.ExpirationDate - DateTime.Now).TotalHours <= ((item.ExpirationDate - item.DateManufacture).TotalHours * 0.2))
                    {
                        item.ChangedPrice = item.Cost * 0.5;
                        await UpdateAsync(item);
                    }
                    if (!item.IsFoodProduct && item.ChangedPrice == 0 && item.Width > 100 || item.Height > 100 )
                    {
                        item.ChangedPrice = item.Cost * 1.5;
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

            if (productDto.IsFoodProduct && exitingsDriver.Cost != productDto.Cost && 
                 (productDto.ExpirationDate - DateTime.Now).TotalHours <= ((productDto.ExpirationDate - productDto.DateManufacture).TotalHours * 0.2))
            {
                productDto.ChangedPrice = productDto.Cost * 0.5;
            }
            if (!productDto.IsFoodProduct && productDto.ChangedPrice == 0 && productDto.Width > 100 || productDto.Height > 100)
            {
                productDto.ChangedPrice = productDto.Cost * 1.5;
            }

            await _productRepository.UpdateAsync(productDto);
            return true;
        }
    }
}
