using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}
