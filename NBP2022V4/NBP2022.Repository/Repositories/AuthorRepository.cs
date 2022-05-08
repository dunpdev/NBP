using Microsoft.EntityFrameworkCore;
using NBP2022.Data;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;
using System.Threading.Tasks;

namespace NBP2022.Repository.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository {
        private readonly NBPDbContext context;

        public AuthorRepository(NBPDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Author> GetAuthorWithCoursesAsync(int id)
        {
            var author = await context.Authors
                                        .Include(a => a.Courses)
                                        .SingleOrDefaultAsync(a => a.Id == id);
            return author;
        }
    }
}