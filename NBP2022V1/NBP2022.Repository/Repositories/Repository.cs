using Microsoft.EntityFrameworkCore;
using NBP2022.Data;
using NBP2022.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBP2022.Repository.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NBPDbContext context;
        public Repository(NBPDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            context.SaveChanges();
        }
        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var element = await context.Set<T>().FindAsync(id);
            return element;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await context.Set<T>().ToListAsync();
            return list;
        }
    }
}