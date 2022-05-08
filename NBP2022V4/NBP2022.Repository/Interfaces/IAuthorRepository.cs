using NBP2022.Data.Models;
using System.Threading.Tasks;

namespace NBP2022.Repository.Interfaces
{
    public interface IAuthorRepository : IRepository<Author> {
        Task<Author> GetAuthorWithCoursesAsync(int id);
    }
}