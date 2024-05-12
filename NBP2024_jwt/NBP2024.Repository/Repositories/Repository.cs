using Microsoft.EntityFrameworkCore;
using NBP2024.Domain.Interfaces;
using NBP2024.Infrastructure;

namespace NBP2024.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PlutoContext context;
        public Repository(PlutoContext context){
            this.context = context;
        }
        public async Task<T> Create(T entity){
            await context.Set<T>().AddAsync(entity);
            return entity;
        }
        public async Task<T> Remove(int id){
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
                context.Set<T>().Remove(entity);
            return entity;
        }
        public async Task<IEnumerable<T>> GetAll(){
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
