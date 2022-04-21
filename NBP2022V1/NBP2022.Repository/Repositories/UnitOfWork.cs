using NBP2022.Data;
using NBP2022.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NBPDbContext context;

        public ICourseRepository CourseRepository { get; set; }
        public IAuthorRepository AuthorRepository { get; set; }
        public ITagRepository TagRepository { get; set; }
        public UnitOfWork(NBPDbContext context,
            ICourseRepository courseRepository,
            IAuthorRepository authorRepository,
            ITagRepository tagRepository)
        {
            this.context = context;
            CourseRepository = courseRepository;
            AuthorRepository = authorRepository;
            TagRepository = tagRepository;
        }
        public async Task Complete()
        {
            await context.SaveChangesAsync();
        }
    }
}
