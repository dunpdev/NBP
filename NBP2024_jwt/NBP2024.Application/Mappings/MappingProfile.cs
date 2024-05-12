using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NBP2024.Application.DTOs;
using NBP2024.Domain.Models;

namespace NBP2024.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Models to DTOs
            CreateMap<Course, CourseDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Tag, TagDTO>();

            // DTOs to Models
            CreateMap<CreateCourseDTO, Course>();
        }
    }
}
