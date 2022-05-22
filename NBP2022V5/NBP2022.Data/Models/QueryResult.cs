using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Data.Models
{
        public class QueryResult<T>
        {
            public int Total { get; set; }
            public IEnumerable<T> Items { get; set; }
        
    }
}
