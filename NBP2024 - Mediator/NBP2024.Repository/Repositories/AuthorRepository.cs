using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using NBP2024.Infrastructure;

namespace NBP2024.Repository.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(PlutoContext context) : base(context)
        {
        }
    }
}
