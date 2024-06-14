using MediatR;
using NBP2024.API.Mediator.Course.Query;
using NBP2024.Application.DTOs;
using NBP2024.Application.Services;
using NBP2024.Domain.Exepctions;
using NBP2024.Domain.Models;

namespace NBP2024.API.Mediator.Course.Handler
{
    public class CourseIdHandler : IRequestHandler<CourseIdQuery, Result<CourseDTO>>
    {
        private readonly CoursesService service;

        public CourseIdHandler(CoursesService service)
        {
            this.service = service;
        }
        public async Task<Result<CourseDTO>> Handle(CourseIdQuery request, CancellationToken cancellationToken)
        {
            var course = await service.GetById(request.Id);
            if (course == null)
            {
                throw new EntityNullCustomException();
                //return new Result<CourseDTO>
                //{
                //    IsSuccess = false,
                //    Errors = new List<string>() { $"Course with id = {request.Id} does not exist!" }
                //};
            }
            return new Result<CourseDTO> { Data =  course };
        }
    }
}
