using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.DTOs
{
    public class StudentClassroomDto
    {
        public int StudentId { get; set; }

        public StudentDto Student { get; set; }

        public int ClassRoomId { get; set; }

        public ClassroomDto Classroom { get; set; }
    }
}
