using System.Collections.Generic;

namespace AWSServerless.Domain.Entities
{
    public class Student
    {
        public IList<StudentClassroom> StudentClassrooms { get; set; }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double GPA { get; set; }
    }
}