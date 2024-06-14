namespace NBP2024.Application.DTOs
{
    public class CreateCourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }
        public int AuthorId { get; set; }
        public int CoverId { get; set; }
    }
}
