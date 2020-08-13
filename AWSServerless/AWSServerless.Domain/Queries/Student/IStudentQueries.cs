using AWSServerless.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless.Domain.Queries.Student
{
    public interface IStudentQueries: IQueries<StudentDto, Entities.Student>
    {
    }
}
