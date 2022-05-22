
namespace NBP2022.Data.Models
{
    public class CourseQuery : IQueryObject
    {
        public int? AuthorId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}