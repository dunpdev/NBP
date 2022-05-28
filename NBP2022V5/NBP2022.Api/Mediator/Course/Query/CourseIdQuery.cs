using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NBP2022.Api.DTOs;
using NBP2022.Data.Models;

namespace NBP2022.Api.Mediator.Course.Query
{
    public class CourseIdQuery : IRequest<Result<CourseDTO>>
    {
        public CourseIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
