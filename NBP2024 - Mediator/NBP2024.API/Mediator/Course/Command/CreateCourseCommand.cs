using MediatR;
using NBP2024.Application.DTOs;
using NBP2024.Domain.Models;

namespace NBP2024.API.Mediator.Course.Command
{
    public class CreateCourseCommand : IRequest<Result<CourseDTO>>
    {
        public string Name { get; }
        public string Description { get; }
        public int Level { get; }
        public float FullPrice { get; }
        public int AuthorId { get; }
        public int CoverId { get; }
        public CreateCourseCommand(string name, string description, int level, float fullPrice, int authorId, int coverId)
        {
            Name = name;
            Description = description;
            Level = level;
            FullPrice = fullPrice;
            AuthorId = authorId;
            CoverId = coverId;
        }
    }
}
