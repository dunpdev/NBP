using AutoMapper;
using NBP2022.Api.DTOs;
using NBP2022.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBP2022.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Models to DTOs
            CreateMap<Author, AuthorDTO>()
                .ForMember(d => d.Contact, opt => opt.MapFrom(s => new ContactDTO
                {
                    Address = s.ContactAddress,
                    Email = s.ContactEmail,
                    Phone = s.ContactPhone,
                    Town = s.City
                }));
            CreateMap<Course, CourseDTO>();
            #endregion

            #region DTOs to Models
            CreateMap<SaveAuthorDTO,Author>()
                .ForMember(d => d.City, s => s.MapFrom(d => d.Contact.Town));
            CreateMap<CourseDTO, Course>();
            #endregion
        }
    }
}
