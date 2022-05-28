using AutoMapper;
using MediatR;
using NBP2022.Api.DTOs;
using NBP2022.Api.Mediator.Course.Command;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBP2022.Api.Mediator.Course.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CourseCommand, Result<CourseDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateCourseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Result<CourseDTO>> Handle(CourseCommand request, CancellationToken cancellationToken)
        {
            // TODO: Custom validation checks with throw custom exception
            var course = mapper.Map<NBP2022.Data.Models.Course>(request);
            await unitOfWork.CourseRepository.AddAsync(course);
            await unitOfWork.CompleteAsync();
            var courseDTO = mapper.Map<CourseDTO>(course);
            Result<CourseDTO> result = new Result<CourseDTO>
            {
                Data = courseDTO
            };
            return result;
        }
    }
}
