using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using NBP2024.Infrastructure.MongoDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Repository.Repositories
{
    public class CoursesMongoRepository : ICourseRepository
    {
        private readonly MongoService service;

        public CoursesMongoRepository(MongoService service)
        {
            this.service = service;
        }
        public async Task<Course> Create(Course entity)
        {
            var result = await service.Create(entity);
            return result;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var result = await service.GetAll();
            return result;
        }

        public async Task<Course> GetById(int id)
        {
            var result = await service.GetById(id);
            return result;
        }

        public Task<IEnumerable<Course>> GetCheaperThen50()
        {
            throw new NotImplementedException();
        }

        public Task<Course> Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
