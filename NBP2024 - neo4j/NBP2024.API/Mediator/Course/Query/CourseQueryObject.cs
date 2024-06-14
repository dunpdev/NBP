using NBP2024.Domain.Models;

namespace NBP2024.API.Mediator.Course.Query
{
    public class CourseQueryObject : IQueryObject // za domaci kreirati handler i implementirao pomocu Mediator-a
    {
        public int? Level { get; set; }
        public bool IsSortAsc { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
