using NBP2022.Data;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;

namespace NBP2022.Repository.Repositories
{
    public class CourseRepository : Repository<Author>, ICourseRepository
    {
        public CourseRepository(NBPDbContext context) : base(context)
        {

        }
    }
}