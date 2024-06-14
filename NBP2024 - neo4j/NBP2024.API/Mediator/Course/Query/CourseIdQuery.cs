using MediatR;
using NBP2024.Application.DTOs;
using NBP2024.Domain.Models;

namespace NBP2024.API.Mediator.Course.Query
{
    //public record CourseIdQuery(int Id) : IRequest<CourseDTO>;
    public class CourseIdQuery : IRequest<Result<CourseDTO>>
    {
        public int Id { get; }
        public CourseIdQuery(int id) {
            Id = id;
        }
    }
}
