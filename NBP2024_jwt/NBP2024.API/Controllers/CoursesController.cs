using Microsoft.AspNetCore.Mvc;
using NBP2024.Application.DTOs;
using NBP2024.Application.Services;
using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using NBP2024.Infrastructure;

namespace NBP2024.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : Controller
    {
        private readonly CoursesService service;

        public CoursesController(CoursesService service) {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var courses = await service.GetAllCourses();
            return Ok(courses);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCourseDTO course)
        {
            var courses = await service.Create(course);
            return Ok(courses);
        }
    }
}
