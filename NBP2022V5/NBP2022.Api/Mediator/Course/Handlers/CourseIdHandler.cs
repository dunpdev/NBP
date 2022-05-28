using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using NBP2022.Api.DTOs;
using NBP2022.Api.Mediator.Course.Query;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;
using NBP2022.Repository.Repositories;

namespace NBP2022.Api.Mediator.Course.Handlers
{
    public class CourseIdHandler : IRequestHandler<CourseIdQuery, Result<CourseDTO>>
    {
        private readonly ICourseRepository repository;
        private readonly IMapper mapper;

        public CourseIdHandler(ICourseRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<Result<CourseDTO>> Handle(CourseIdQuery request, CancellationToken cancellationToken)
        {
            var course = await repository.GetByIdAsync(request.Id);
            if (course == null)
                return new Result<CourseDTO>
                {
                    Data = new CourseDTO(),
                    IsSuccess = false,
                    Errors = new List<string> { "Id is not valid" }
                };
            var courseDTO = mapper.Map<CourseDTO>(course);

            return new Result<CourseDTO>
            {
                Data = courseDTO
            };

        }
    }
}
