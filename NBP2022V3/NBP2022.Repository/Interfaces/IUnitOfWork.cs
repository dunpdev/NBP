using NBP2022.Repository.Interfaces;
using System.Threading.Tasks;

namespace NBP2022.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; set; }
        ICourseRepository CourseRepository { get; set; }
        ITagRepository TagRepository { get; set; }

        Task CompleteAsync();
    }
}