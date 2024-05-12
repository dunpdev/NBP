using AutoMapper;
using NBP2024.Application.DTOs;
using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Application.Services
{
    public class CoursesService
    {
        private readonly ICourseRepository CourseRepository;
        private readonly IMapper mapper;

        public CoursesService(ICourseRepository CourseRepository, IMapper mapper)
        {
            this.CourseRepository = CourseRepository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = await CourseRepository.GetAll();
            return mapper.Map<List<CourseDTO>>(courses);
        }
        public async Task<CourseDTO?> GetById(int id) { return null; }
        public async Task<CourseDTO?> Create(CreateCourseDTO course) {
            var newCourse = mapper.Map<Course>(course);
            await CourseRepository.Create(newCourse);
            //await uow.CompleteAsync();
            return mapper.Map<CourseDTO>(newCourse);
            }
        public async Task<CourseDTO?> Update(int id, CourseDTO course) { return null; }
        public async Task<CourseDTO?> Delete(int id) { return null; }
    }
}
