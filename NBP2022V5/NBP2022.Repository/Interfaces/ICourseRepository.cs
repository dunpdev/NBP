using NBP2022.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBP2022.Repository.Interfaces
{
    public interface ICourseRepository : IRepository<Course> {
        List<Course> GetCourse(CourseQuery queryObj);
            }
}