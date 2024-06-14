using AutoMapper;
using NBP2024.Application.DTOs;
using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Application.Services
{
    public class CoursesService
    {
        private readonly ICourseRepository CourseRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork uow;

        public CoursesService(ICourseRepository CourseRepository, IMapper mapper, IUnitOfWork uow)
        {
            this.CourseRepository = CourseRepository;
            this.mapper = mapper;
            this.uow = uow;
        }
        public async Task<IQueryable<CourseDTO>> GetAllCourses()
        {
            var courses = await CourseRepository.GetAll();
            var result = mapper.Map<List<CourseDTO>>(courses);
            return result.AsQueryable();
        }
        public async Task<CourseDTO?> GetById(int id) {
            var course = await CourseRepository.GetById(id);
            return mapper.Map<CourseDTO>(course);
        }
        public async Task<CourseDTO?> Create(CreateCourseDTO course) {
            var newCourse = mapper.Map<Course>(course);
            await CourseRepository.Create(newCourse);
            await uow.CompleteAsync();
            return mapper.Map<CourseDTO>(newCourse);
            }
        public async Task<CourseDTO?> Update(int id, CourseDTO course) { return null; }
        public async Task<CourseDTO?> Delete(int id) {
            var course = await CourseRepository.Remove(1);
            await uow.CompleteAsync();
            return mapper.Map<CourseDTO>(course);
        }
    }
}
