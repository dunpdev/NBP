using NBP2024.Domain.Models;

namespace NBP2024.Domain.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task AuthorCourseRel(int authorId, int courseId);
    }
}
