

using Skladala.Core.Models;
using Skladala.Persistence.Repository.Interfaces;

namespace Skladala.App.Services
{
    public class FoodProductServices
    {
        private readonly IRepository<FoodProduct> _foodProductRepository;

        public FoodProductServices(IRepository<FoodProduct> foodProductRepository)
        {
            _foodProductRepository = foodProductRepository;
        }

        public async Task<IEnumerable<FoodProduct>> GetAsync()
        {
            try
            {
                return await _foodProductRepository.GetAsync(default);
            }
            catch
            {
                return null;
            }
        }
        public async Task<bool> CreateAsync(FoodProduct model)
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
