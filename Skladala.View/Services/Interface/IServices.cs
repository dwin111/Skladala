using Skladala.Persistence.Models;

namespace Skladala.View.Services.Interface
{
    public interface IServices <T>
    {

        public Task<List<T>> GetAsync();

    }
}
