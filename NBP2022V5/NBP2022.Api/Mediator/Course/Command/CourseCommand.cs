using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using NBP2022.Api.DTOs;
using NBP2022.Data.Models;

namespace NBP2022.Api.Mediator.Course.Command
{
    public class CourseCommand : IRequest<Result<CourseDTO>>
    {
        public string Name { get; }
        public string Description { get; }
        public int Level { get; }
        public float FullPrice { get; }
        public int AuthorId { get; }
        public CourseCommand(string Name,string Description,int Level,float FullPrice,int AuthorId)
        {
            this.Name = Name;
            this.Description = Description;
            this.Level = Level;
            this.FullPrice = FullPrice;
            this.AuthorId = AuthorId;
        }
    }
}
