
using NBP2022.Api.Extensions;
using NBP2022.Data.Models;

namespace NBP2022.Api.DTOs
{
    public class CourseQueryDTO : IQueryObject
    {
        // Filtriranje
        public int? AuthorId { get; set; }
        // Sortiranje
        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }
        // Paginacija
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}