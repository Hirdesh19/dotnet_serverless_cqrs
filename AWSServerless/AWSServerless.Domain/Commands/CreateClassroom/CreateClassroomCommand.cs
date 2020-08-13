using AWSServerless.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Commands.CreateClassroom
{
    public class CreateClassroomCommand: IRequest<ClassroomDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public IList<int> StudentIds { get; set; } = new List<int>();

        public int TeacherId { get; set; }
    }
}
