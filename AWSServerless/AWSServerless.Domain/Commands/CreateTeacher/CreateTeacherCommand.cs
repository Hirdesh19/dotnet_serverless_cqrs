using AWSServerless.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Commands.CreateTeacher
{
    public class CreateTeacherCommand: IRequest<TeacherDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
