using NBP2024.Domain.Interfaces;

namespace NBP2024.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }
        ICourseRepository CourseRepository { get; }

        Task<int> CompleteAsync();
    }
}