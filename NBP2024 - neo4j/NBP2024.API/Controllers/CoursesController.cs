using MediatR;
using Microsoft.AspNetCore.Mvc;
using NBP2024.API.Extensions;
using NBP2024.API.Mediator.Course.Command;
using NBP2024.API.Mediator.Course.Query;
using NBP2024.Application.DTOs;
using NBP2024.Application.Services;
using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using NBP2024.Infrastructure;
using System.Linq.Expressions;

namespace NBP2024.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly IMediator mediator;
        private readonly CoursesService service;

        public CoursesController(IMediator mediator, CoursesService service) {
            this.mediator = mediator;
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CourseQueryObject queryObject){

            Dictionary<string, Expression<Func<CourseDTO, object>>> columnMaps = 
                new Dictionary<string, Expression<Func<CourseDTO, object>>>
            {
                ["Name"] = c => c.Name,
                ["Level"] = c => c.Level
            };
            var courses = await service.GetAllCourses();

            if(queryObject.Level.HasValue)
                courses = courses.Where(c => c.Level == queryObject.Level).AsQueryable();

            courses = courses.ApplySorting<CourseDTO>(queryObject, columnMaps).ApplyPaging<CourseDTO>(queryObject);

            var result = new ResultQuery<CourseDTO>();

            result.Total = courses.Count();
            result.Items = courses.ToList();

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new CourseIdQuery(id));
            if (!result.IsSuccess)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCourseCommand course)
        {
            var result = await mediator.Send(course);
            if (!result.IsSuccess)
                return BadRequest(result.Errors);
            return Ok(result.Data);
        }
    }
}
