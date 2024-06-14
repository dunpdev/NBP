using Microsoft.EntityFrameworkCore;
using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using NBP2024.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Repository.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly PlutoContext context;
        public CourseRepository(PlutoContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Course>> GetCheaperThen50(){
            return await context.Courses.Where(c => c.FullPrice < 50).ToListAsync();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await context.Courses.Include(c => c.Author).ToListAsync();
        }
    }
}
