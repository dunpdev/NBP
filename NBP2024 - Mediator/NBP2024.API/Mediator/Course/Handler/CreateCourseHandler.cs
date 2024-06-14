using AutoMapper;
using MediatR;
using NBP2024.API.Mediator.Course.Command;
using NBP2024.Application.DTOs;
using NBP2024.Application.Services;
using NBP2024.Domain.Models;

namespace NBP2024.API.Mediator.Course.Handler
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Result<CourseDTO>>
    {
        private readonly CoursesService service;

        public CreateCourseHandler(CoursesService service)
        {
            this.service = service;
        }
        public async Task<Result<CourseDTO>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new CreateCourseDTO
            {
                Name = request.Name,
                Description = request.Description,
                FullPrice = request.FullPrice,
                AuthorId = request.AuthorId,
                CoverId = request.CoverId,
                Level = request.Level
            };
            var newCourse = await service.Create(course);
            if(newCourse == null)
            {
                return new Result<CourseDTO>
                {
                    IsSuccess = false,
                    Errors = new List<string>() { "There is some error in adding new course" }
                };
            }
            return new Result<CourseDTO>{ Data = newCourse };
        }
    }
}
