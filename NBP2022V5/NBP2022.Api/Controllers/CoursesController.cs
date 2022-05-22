using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBP2022.Api.DTOs;
using NBP2022.Api.Extensions;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;
using MediatR;
using NBP2022.Api.Mediator.Course.Query;

namespace NBP2022.Api.Controllers
{
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ICourseRepository courseRepository;
        private readonly IMediator mediator;

        public CoursesController(IUnitOfWork unitOfWork,
            IMapper mapper, 
            ICourseRepository courseRepository,
            IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.courseRepository = courseRepository;
            this.mediator = mediator;
        }

        [HttpGet]
        public QueryResultDTO<CourseDTO> GetAll([FromQuery]CourseQueryDTO queryObjResource)
        {
            var queryObj = mapper.Map<CourseQueryDTO,CourseQuery>(queryObjResource);
            
            var query = courseRepository.GetCourse(queryObj).AsQueryable();

            if (queryObj.AuthorId.HasValue)
                query = query.Where(c => c.AuthorId == queryObj.AuthorId);

            var columnsMap = new Dictionary<string, Expression<Func<Course, object>>>()
            {
                ["Name"] = c => c.Name,
                ["Level"] = c => c.Level,
                ["AuthorId"] = c => c.AuthorId
            };

            query = query.ApplySorting(queryObj, columnsMap);

            query = query.ApplyPaging(queryObj);

            var result = new QueryResult<Course>();

            result.Total =  query.Count();

            result.Items =  query.ToList();

            return mapper.Map<QueryResult<Course>, QueryResultDTO<CourseDTO>>(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await mediator.Send(new CourseIdQuery(id));
            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}