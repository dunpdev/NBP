using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using NBP2024.Infrastructure.GraphDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Repository.Repositories
{
    public class AuthorsGraphRepository : IAuthorRepository
    {
        private readonly AuthorsGraphDbContext context;

        public AuthorsGraphRepository(AuthorsGraphDbContext context)
        {
            this.context = context;
        }
        public async Task<Author> Create(Author entity)
        {
            await context.CreateAuthor(entity);
            return entity;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await context.GetAuthorsAsync();
        }

        public async Task AuthorCourseRel(int authorId,int courseId) {
            await context.AuthorTeachesCourse(authorId, courseId);
        }

        public async Task<Author> GetById(int id)
        {
            throw new Exception();
        }

        public Task<Author> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
