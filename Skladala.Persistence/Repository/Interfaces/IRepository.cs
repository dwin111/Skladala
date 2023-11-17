
namespace Skladala.Persistence.Repository.Interfaces
{
    public interface IRepository<T>
    {

        Task<T> GetAsync(string id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
        Task CreateAsync(T model);
        Task UpdateAsync(T model);
        Task DeleteAsync(string id, CancellationToken cancellationToken);

    }
}
