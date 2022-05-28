using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Data.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
