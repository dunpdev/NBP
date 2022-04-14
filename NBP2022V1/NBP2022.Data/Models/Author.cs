using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2022.Data.Models
{
    public class Author
    {
        public Author()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

}
