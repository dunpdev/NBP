namespace NBP2022.Data.Models
{
    public interface IQueryObject
    {
        string SortBy { get; set; }
        bool IsSortAsc { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}