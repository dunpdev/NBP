using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Domain.Models
{
    public interface IQueryObject
    {
        bool IsSortAsc { get; set; }
        string SortBy { get; set; }
        int Page {  get; set; }
        int PageSize { get; set; }
    }
}
