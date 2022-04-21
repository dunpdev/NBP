using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBP2022.Data.Models
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }

}
