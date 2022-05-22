using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBP2022.Api.DTOs
{
    public class QueryResultDTO<T>
    {
        public int Total { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
