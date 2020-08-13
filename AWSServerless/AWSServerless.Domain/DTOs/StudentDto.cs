using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.DTOs
{
    public class StudentDto
    {
        public IList<StudentClassroomDto> StudentClassrooms { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double GPA { get; set; }
    }
}
