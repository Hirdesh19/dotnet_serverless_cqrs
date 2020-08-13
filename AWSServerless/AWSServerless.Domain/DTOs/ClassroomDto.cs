using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.DTOs
{
    public class ClassroomDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public IList<StudentClassroomDto> StudentClassrooms { get; set; }

        public int TeacherId { get; set; }

        public TeacherDto Teacher { get; set; }
    }
}
