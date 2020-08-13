using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AWSServerless.Domain.Entities
{
    public class Classroom
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public IList<StudentClassroom> StudentClassrooms { get; set; }

        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        public Teacher Teacher { get; set; }
    }
}