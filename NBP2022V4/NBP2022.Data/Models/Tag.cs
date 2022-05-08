using System.Collections.Generic;

namespace NBP2022.Data.Models
{
    public class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

}
