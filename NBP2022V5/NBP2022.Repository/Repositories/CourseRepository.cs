using Microsoft.EntityFrameworkCore;
using NBP2022.Data;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NBP2022.Repository.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly NBPDbContext context;

        public CourseRepository(NBPDbContext context) : base(context)
        {
            this.context = context;
        }
        public List<Course> GetCourse(CourseQuery queryObj)
        {
            var query = context.Courses
            .Include(c => c.Author).AsQueryable();

            return query.ToList();
        }
    }
}