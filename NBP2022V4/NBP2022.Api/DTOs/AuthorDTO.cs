using System.Collections.Generic;

namespace NBP2022.Api.DTOs
{
    public class AuthorDTO
    {
        public AuthorDTO()
        {
            Courses = new HashSet<CourseDTO>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ContactDTO Contact { get; set; }
        public ICollection<CourseDTO> Courses { get; set; }
    }
}
