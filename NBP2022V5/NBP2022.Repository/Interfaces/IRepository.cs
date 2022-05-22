using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBP2022.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Remove(T entity);
    }
}