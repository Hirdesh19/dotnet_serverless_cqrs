using AWSServerless.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<StudentDto>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double GPA { get; set; }

        public IList<int> ClassroomIds { get; set; } = new List<int>();
    }
}
