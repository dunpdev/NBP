using NBP2022.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBP2022.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author> { }
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        void Remove(T entity);
    }
}