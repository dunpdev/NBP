using NBP2024.Domain.Interfaces;
using NBP2024.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext context;

        public IAuthorRepository AuthorRepository { get; }
        public ICourseRepository CourseRepository { get; }
        public UnitOfWork(IAuthorRepository authorRepository, ICourseRepository courseRepository,
            PlutoContext context)
        {
            AuthorRepository = authorRepository;
            CourseRepository = courseRepository;
            this.context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
